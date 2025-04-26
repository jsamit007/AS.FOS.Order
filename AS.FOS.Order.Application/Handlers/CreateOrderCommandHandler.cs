using AS.FOS.App.Common.Application.Events;
using AS.FOS.App.Common.Domain.ValueObject;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Application.Response;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.Entities;
using AS.FOS.Order.Domain.ValueObjects;
using AutoMapper;
using MediatR;

namespace AS.FOS.Order.Application.Handlers;

internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IResturantRepository _resturantRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository, 
        IEventPublisher eventPublisher,
        IMapper mapper,
        IResturantRepository resturantRepository,
        IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
        _mapper = mapper;
        _resturantRepository = resturantRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (!_resturantRepository.IsRestaurantOpen(request.RestaurantId))
        {
            throw new Exception("Restaurant is closed");
        }
        var order = new OrderEntity(new CustomerId(request.CustomerId), new RestaurantId(request.RestaurantId), _mapper.Map<DeliveryAddress>(request.DeliveryAddress));

        foreach (var item in request.Items)
        {
            order.AddItem(new OrderItem(item.ProductId, item.Quantity, item.Price));
        }

        order.Create();

        await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();

        return new CreateOrderResponse(order.Id);
    }
}
