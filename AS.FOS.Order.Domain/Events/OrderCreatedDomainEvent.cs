using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.Order.Domain.Events;

internal class OrderCreatedDomainEvent : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
    public decimal Amount { get; init; }
    public Guid OrderId { get; init; }
    public Guid CustomerId { get; init; }
    public Guid ResturantId { get; init; }
}
