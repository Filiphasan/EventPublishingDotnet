using System.Reflection;

namespace MainService;

public static class DependencyInjection
{
    public static IServiceCollection RegisterWebLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}