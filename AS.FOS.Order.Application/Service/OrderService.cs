using AS.FOS.Order.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace AS.FOS.Order.Application.Service;

internal class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task MarkOrderAsPaidAsync(Guid orderId,CancellationToken token)
    {
        _logger.LogInformation("OrderService.MarkOrderAsPaidAsync - Start");
        var order = await _orderRepository.GetByIdAsync(orderId,token);
        if (order == null)
            throw new Exception("Order not found!");
        order.Pay();
        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync(token);
        _logger.LogInformation("OrderService.MarkOrderAsPaidAsync - Completed");
    }

    public async Task MarkOrderAsPaymentFailedAsync(Guid orderId, string reason, CancellationToken token)
    {
        _logger.LogInformation("OrderService.MarkOrderAsPaymentFailedAsync - Start");
        var order = await _orderRepository.GetByIdAsync(orderId, token);
        if (order == null)
            throw new Exception("Order not found!");
        order.Fail();
        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync(token);
        _logger.LogInformation("OrderService.MarkOrderAsPaymentFailedAsync - Completed");
    }
}
