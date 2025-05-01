using AS.FOS.App.Common.Events.Payment;
using AS.FOS.Order.Application.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AS.FOS.Order.Infrastructure.Messaging.Consumer;

internal class PaymentFailedConsumer : IConsumer<PaymentFailedEvent>
{
    private readonly IOrderService _orderService;
    private readonly ILogger<PaymentSucceededConsumer> _logger;

    public PaymentFailedConsumer(IOrderService orderService, ILogger<PaymentSucceededConsumer> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<PaymentFailedEvent> context)
    {
        var @event = context.Message;
        _logger.LogInformation($"Payment succeeded for OrderId: {@event.OrderId}");

        await _orderService.MarkOrderAsPaymentFailedAsync(@event.OrderId,@event.Reason, new CancellationToken());
    }
}
