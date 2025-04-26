
using AS.FOS.Order.Domain.Aggregates;

namespace AS.FOS.Order.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(OrderEntity order);
    Task<OrderEntity> GetByIdAsync(Guid orderId,CancellationToken token);
    Task UpdateAsync(OrderEntity order);
}