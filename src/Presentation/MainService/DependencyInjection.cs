using System.Reflection;
using Core.Constancts;
using Core.Events.Orders;
using Core.Models.OptionModels;
using MainService.MessageBroker.Implementation;
using MainService.MessageBroker.Interface;
using MassTransit;
using Microsoft.Extensions.Options;

namespace MainService;

public static class DependencyInjection
{
    public static IServiceCollection RegisterWebLayer(this IServiceCollection services)
    {
        var settingModel = services.BuildServiceProvider().GetRequiredService<IOptions<AppsettingOption>>().Value;
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.RegisterServices();
        services.RegisterMasstransit(settingModel);
        return services;
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IPublisherService, PublisherService>();
    }

    private static void RegisterMasstransit(this IServiceCollection services, AppsettingOption settingModel)
    {
        services.AddMassTransit(opt =>
        {
            opt.UsingRabbitMq((context, config) =>
            {
                config.Host(settingModel.RabbitMq.Host, r =>
                {
                    r.Username(settingModel.RabbitMq.Username);
                    r.Password(settingModel.RabbitMq.Password);
                });

                config.Message<CreateOrderEvent>(x => x.SetEntityName(MessageBrokerConstant.ExchangeNames.CreateOrder));

                config.ConfigureEndpoints(context);
            });
        });
    }
}
