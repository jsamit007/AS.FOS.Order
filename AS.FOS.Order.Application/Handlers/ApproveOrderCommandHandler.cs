using AS.FOS.App.Common.Application;
using AS.FOS.Order.Application.Commands;
using AS.FOS.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.FOS.Order.Application.Handlers;

internal class ApproveOrderCommandHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEventPublisher _eventPublisher;

    public ApproveOrderCommandHandler(IOrderRepository orderRepository, IEventPublisher eventPublisher)
    {
        _orderRepository = orderRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task Handle(ApproveOrderCommand command)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId);
        order.Approve();

        await _orderRepository.UpdateAsync(order);

        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent);
        }

        order.ClearDomainEvents();
    }
}
