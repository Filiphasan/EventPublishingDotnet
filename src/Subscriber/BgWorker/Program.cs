using BgWorker;
using BgWorker.Logging;
using Core;
using Data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterLogger();
builder.Services
    .RegisterCoreLayer(builder.Configuration)
    .RegisterDataLayer()
    .RegisterBgWorkerLayer();

var host = builder.Build();
host.Run();
