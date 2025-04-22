using AS.FOS.App.Common.Domain.Event;
using AS.FOS.Order.Domain.Aggregates;

namespace AS.FOS.Order.Domain.Events;

internal class OrderPaidDomainEvent : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;

    public OrderEntity Order { get;  }

    public OrderPaidDomainEvent(OrderEntity order)
    {
        Order = order;
    }
}
