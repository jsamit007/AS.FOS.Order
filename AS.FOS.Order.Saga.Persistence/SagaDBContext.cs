using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace AS.FOS.Order.Saga.Persistence;

internal class SagaDBContext : SagaDbContext
{
    public SagaDBContext(DbContextOptions<SagaDBContext> options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations
    {
        get { yield return new OrderStateMap(); }
    }
}
