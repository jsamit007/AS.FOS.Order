
namespace AS.FOS.App.Common.Events.Payment;

public class PaymentSucceededEvent
{
    public Guid OrderId { get; set; }
    public DateTime PaidAt { get; set; }
}
