using Core.Models.OptionModels;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
    {
        var appSettingsOptions = services.BuildServiceProvider().GetRequiredService<IOptions<AppsettingOption>>();
        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseNpgsql(appSettingsOptions.Value.Postgres.ConnectionString,
                sqlOptions => sqlOptions.EnableRetryOnFailure(5));
        });

        services.AddSingleton<IMongoClient>(new MongoClient(appSettingsOptions.Value.Mongo.ConnectionString));
        services.AddSingleton<MongoDbContext>();

        return services;
    }
}
