using AS.FOS.App.Common.Events.Order;
using AS.FOS.App.Common.Events.Payment;
using AS.FOS.Order.Saga;
using MassTransit;

namespace AS.FOS.Order.Infrastructure.Saga.Machine;

internal class OrderStateMachine : MassTransitStateMachine<OrderState>
{
    public State Submitted { get; private set; }
    public State Paid { get; private set; }
    public State Failed { get; private set; }

    public Event<OrderCreatedEvent> OrderCreated { get; private set; }
    public Event<PaymentSucceededEvent> PaymentSucceeded { get; private set; }
    public Event<PaymentFailedEvent> PaymentFailed { get; private set; }

    public OrderStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => OrderCreated, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => PaymentSucceeded, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => PaymentFailed, x => x.CorrelateById(m => m.Message.OrderId));

        Initially(
            When(OrderCreated)
                .Then(context =>
                {
                    context.Saga.OrderId = context.Message.OrderId;
                    context.Saga.CreatedAt = DateTime.UtcNow;
                    // TODO: Publish command to initiate payment
                })
                .TransitionTo(Submitted)
        );

        During(Submitted,
            When(PaymentSucceeded)
                .ThenAsync(context =>
                {
                    // TODO: Approve the order
                    return Task.CompletedTask;
                })
                .TransitionTo(Paid),

            When(PaymentFailed)
                .ThenAsync(context =>
                {
                    // TODO: Cancel the order
                    return Task.CompletedTask;
                })
                .TransitionTo(Failed)
        );
    }
}
