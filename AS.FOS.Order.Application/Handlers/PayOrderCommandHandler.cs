using AS.FOS.App.Common.Application;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Application.Response;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AS.FOS.Order.Application.Handlers;

internal class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, PayOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;

    public PayOrderCommandHandler(IOrderRepository orderRepository, IEventPublisher eventPublisher)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<PayOrderResponse> Handle(PayOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId,cancellationToken);
        order.Pay();

        await _orderRepository.UpdateAsync(order);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();

        return new PayOrderResponse
        {
            OrderId = order.Id,
            CustomerId = order.CustomerId,
            RestaurantId = order.RestaurantId,
            Status = order.Status.ToString()
        };
    }
}
