using MassTransit;

namespace AS.FOS.Order.Saga;

public class OrderState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; }

    public Guid OrderId { get; set; }
    public Guid? PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }
}
