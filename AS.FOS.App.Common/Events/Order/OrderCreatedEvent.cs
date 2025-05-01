using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.App.Common.Events.Order;

public class OrderCreatedEvent : IDomainEvent
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime OccurredOn => DateTime.Now;
    public Guid CustomerId { get; set; }
}
