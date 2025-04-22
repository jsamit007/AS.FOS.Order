using AS.FOS.App.Common.Domain.Event;
using AS.FOS.Order.Domain.Aggregates;

namespace AS.FOS.Order.Domain.Events;

internal class OrderApprovedDomainEvent : IDomainEvent
{
    public DateTime OccurredOn => throw new NotImplementedException();

    internal OrderEntity Order { get; }

    public OrderApprovedDomainEvent(OrderEntity order)
    {
        Order = order;
    }
}
