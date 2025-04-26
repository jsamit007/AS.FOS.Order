using AS.FOS.App.Common.Application;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Application.Response;
using MediatR;


namespace AS.FOS.Order.Application.Handlers;

internal class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand,ApproveOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;

    public ApproveOrderCommandHandler(IOrderRepository orderRepository, IEventPublisher eventPublisher)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<ApproveOrderResponse> Handle(ApproveOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId,cancellationToken);
        order.Approve();

        await _orderRepository.UpdateAsync(order);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();

        return new ApproveOrderResponse
        {
            OrderId = order.Id,
            CustomerId = order.CustomerId,
            RestaurantId = order.RestaurantId,
            Status = order.Status.ToString()
        };
    }
}
