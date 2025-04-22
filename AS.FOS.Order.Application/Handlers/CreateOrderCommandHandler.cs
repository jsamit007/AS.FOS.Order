using AS.FOS.App.Common.Application;
using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.Entities;
using AS.FOS.Order.Domain.ValueObjects;
using AutoMapper;

namespace AS.FOS.Order.Application.Handlers;

internal class CreateOrderCommandHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IResturantRepository _resturantRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository, 
        IEventPublisher eventPublisher,
        IMapper mapper,
        IResturantRepository resturantRepository)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
        _mapper = mapper;
        _resturantRepository = resturantRepository;
    }

    public async Task<Guid> Handle(CreateOrderCommand command)
    {
        if (!_resturantRepository.IsRestaurantOpen(command.RestaurantId))
        {
            throw new Exception("Restaurant is closed");
        }
        var order = new Domain.Aggregates.OrderEntity(new CustomerId(command.CustomerId), new RestaurantId(command.RestaurantId), _mapper.Map<Domain.ValueObjects.OrderEntity>(command.DeliveryAddress));

        foreach (var item in command.Items)
        {
            order.AddItem(new OrderItem(item.ProductId, item.Quantity, item.Price));
        }

        order.Create();

        await _orderRepository.AddAsync(order);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();

        return order.CustomerId.Value;
    }
}
