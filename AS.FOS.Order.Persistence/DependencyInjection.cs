using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Persistence.Context;
using AS.FOS.Order.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AS.FOS.Order.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfigurationManager configuration)
    {
        services.AddDbContext<OrderDBContext>(options =>
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connection)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);

            options.UseNpgsql(connection);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IResturantRepository, ResturantRepository>();

        return services;
    }
}
