using AS.FOS.Order.Application.Interfaces;
using AS.FOS.Order.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AS.FOS.Order.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}
