using AS.FOS.Order.Application;
using AS.FOS.Order.Core.Extensions;
using System.Reflection;

namespace AS.FOS.Order.API.Extensions;

internal static class ServiceCollectionExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddMediatRInAssemblies(new Assembly[] { Assembly.GetExecutingAssembly() , Assembly.GetAssembly(typeof(IAssemblyMarkerInterface))!});
        services.AddIMapper();
        services.AddModuleService(configuration);
        return services;
    }
}
