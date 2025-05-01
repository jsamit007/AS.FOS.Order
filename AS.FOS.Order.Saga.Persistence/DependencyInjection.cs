using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AS.FOS.Order.Saga.Persistence;

public static class DependencyInjection
{
    public static ISagaRegistrationConfigurator<T> AddSagaEntityFramework<T>(this ISagaRegistrationConfigurator<T> configurator,IConfigurationManager configuration) 
        where T : class, ISaga
    {
        configurator.EntityFrameworkRepository(r =>
         {
             r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
             r.AddDbContext<DbContext,SagaDBContext>((provider, builder) =>
             {
                 builder.UseNpgsql(configuration.GetConnectionString("OrderDb"));
             });
         });
        return configurator;
    }
}
