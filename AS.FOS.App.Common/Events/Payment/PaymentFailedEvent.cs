using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.App.Common.Events.Payment;

public class PaymentFailedEvent : IDomainEvent
{
    public Guid OrderId { get; set; }
    public string Reason { get; set; }
    public DateTime OccurredOn => DateTime.Now;
}