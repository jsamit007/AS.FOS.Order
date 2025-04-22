using AS.FOS.App.Common.Application;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;

namespace AS.FOS.Order.Application.Handlers;

internal class PayOrderCommandHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;

    public PayOrderCommandHandler(IOrderRepository orderRepository, IEventPublisher eventPublisher)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task Handle(PayOrderCommand command)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId);
        order.Pay();

        await _orderRepository.UpdateAsync(order);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();
    }
}
