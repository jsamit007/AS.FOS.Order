
using AS.FOS.App.Common.Domain.Event;

namespace AS.FOS.App.Common.Events.Payment;

public class PaymentSucceededEvent : IDomainEvent
{
    public Guid OrderId { get; set; }
    public DateTime PaidAt { get; set; }
    public DateTime OccurredOn => DateTime.Now;
}
