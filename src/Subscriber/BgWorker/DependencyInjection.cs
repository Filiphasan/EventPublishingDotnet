using BgWorker.Consumers;
using BgWorker.MessageBroker.Implementation;
using BgWorker.MessageBroker.Interface;
using Core.Constancts;
using Core.Models.OptionModels;
using MassTransit;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace BgWorker;

public static class DependencyInjection
{
    public static IServiceCollection RegisterBgWorkerLayer(this IServiceCollection services)
    {
        var settingModel = services.BuildServiceProvider().GetRequiredService<IOptions<AppsettingOption>>().Value;
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
            opt.AddConsumer<CreateOrderConsumer>();
            opt.AddConsumer<CreateOrderPaymentConsumer>();

            opt.UsingRabbitMq((context, config) =>
            {
                config.Host(settingModel.RabbitMq.Host, r =>
                {
                    r.Username(settingModel.RabbitMq.Username);
                    r.Password(settingModel.RabbitMq.Password);
                });

                config.ReceiveEndpoint(MessageBrokerConstant.QueueNames.CreateOrder, x =>
                {
                    x.ConfigureConsumeTopology = false;
                    x.Bind(MessageBrokerConstant.ExchangeNames.CreateOrder, c =>
                    {
                        c.ExchangeType = ExchangeType.Fanout;
                    });
                    x.UseMessageRetry(c => c.Interval(5, TimeSpan.FromMinutes(5)));
                    x.ConfigureConsumer<CreateOrderConsumer>(context);
                });

                config.ReceiveEndpoint(MessageBrokerConstant.QueueNames.CreateOrderPayment, x =>
                {
                    x.ConfigureConsumeTopology = false;
                    x.Bind(MessageBrokerConstant.ExchangeNames.CreateOrder, c =>
                    {
                        c.ExchangeType = ExchangeType.Fanout;
                    });
                    x.UseMessageRetry(c => c.Interval(5, TimeSpan.FromMinutes(5)));
                    x.ConfigureConsumer<CreateOrderPaymentConsumer>(context);
                });
            });
        });
    }
}
