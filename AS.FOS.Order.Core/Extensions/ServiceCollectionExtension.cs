using AS.FOS.Order.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AS.FOS.Order.Core.Extensions;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddModuleService(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddPersistence(configuration);
        return services;
    }

    public static IServiceCollection AddMediatRInAssemblies(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg =>
        {
            foreach (Assembly assembly in assemblies)
            {
                cfg.RegisterServicesFromAssembly(assembly);
            }
        });
        
        return services;
    }

    public static IServiceCollection AddIMapper(this IServiceCollection services, Assembly[] assemblies = null)
    {
        var assembliesToInclude = assemblies ?? FindAllAssemblies("AS.FOS.Order");
        services.AddAutoMapper(assembliesToInclude);

        return services;
    }

    private static Assembly[] FindAllAssemblies(string slnStartWith)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && a.FullName.StartsWith(slnStartWith))
            .ToArray();
        return assemblies;
    }
}
