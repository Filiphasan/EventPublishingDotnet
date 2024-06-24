using System.Reflection;

namespace BasketService;

public static class DependencyInjection
{
    public static IServiceCollection RegisterBasketLayer(this IServiceCollection services)
    {
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
