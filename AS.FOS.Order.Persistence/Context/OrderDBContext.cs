using AS.FOS.Order.Domain.Aggregates;
using AS.FOS.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.FOS.Order.Persistence.Context;

internal class OrderDBContext : DbContext
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<Resturant> Resturants => Set<Resturant>();
    public DbSet<Customer> Cutomers => Set<Customer>();

    public OrderDBContext(DbContextOptions<OrderDBContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDBContext).Assembly);
    }
}
