namespace AS.FOS.Order.Application.Interfaces;

public interface IOrderService
{
    Task MarkOrderAsPaidAsync(Guid orderId,CancellationToken token);
    Task MarkOrderAsPaymentFailedAsync(Guid orderId, string reason,CancellationToken token);
}
