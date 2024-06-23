using Core.Models.OptionModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependencyInjection
{
    public static IServiceCollection RegisterCoreLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppsettingOption>(configuration.GetSection(AppsettingOption.SectionName));
        return services;
    }
}