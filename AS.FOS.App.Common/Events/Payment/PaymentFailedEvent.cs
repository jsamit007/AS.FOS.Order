namespace AS.FOS.App.Common.Events.Payment;

public class PaymentFailedEvent
{
    public Guid OrderId { get; set; }
    public string Reason { get; set; }
}