using Core.Models.OptionModels;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Elasticsearch;

namespace MainService.Logging;

public static class LoggingExtension
{
    public static void RegisterLogger(this IServiceCollection services)
    {
        var model = services.BuildServiceProvider().GetRequiredService<IOptions<AppsettingOption>>().Value;
        ArgumentNullException.ThrowIfNull(model);

        SelfLog.Enable(Console.Error);

        Log.Logger = new LoggerConfiguration()
            .PrepareLoggerConfig(model)
            .CreateLogger();
    }

    private static LoggerConfiguration PrepareLoggerConfig(this LoggerConfiguration loggerConfiguration, AppsettingOption settingModel)
    {
        return loggerConfiguration.MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("Elastic.Apm", Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(settingModel.Elastic.ElasticUri))
            {
                AutoRegisterTemplate = true,
                OverwriteTemplate = true,
                DetectElasticsearchVersion = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7, //Template versiyon
                IndexFormat = $"{settingModel.Elastic.ProjectName}-{settingModel.Elastic.Environment}-logs-" + "{0:yyyy.MM.dd}",
                ModifyConnectionSettings = s => s.BasicAuthentication(settingModel.Elastic.Username, settingModel.Elastic.Password),
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
            })
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithProperty("Environment", settingModel.Elastic.Environment);
    }
}
