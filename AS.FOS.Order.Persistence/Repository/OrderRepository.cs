using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AS.FOS.Order.Persistence.Repository;

internal class OrderRepository : IOrderRepository
{
    private readonly OrderDBContext _context;

    public OrderRepository(OrderDBContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OrderEntity order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderEntity> GetByIdAsync(Guid orderId, CancellationToken token)
    {
        return (await _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == orderId))!;
    }

    public async Task UpdateAsync(OrderEntity order)
    {
        _context.Orders.Update(order);
    }
}
