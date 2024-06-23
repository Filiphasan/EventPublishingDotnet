using BgWorker;
using Core;
using Data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .RegisterCoreLayer(builder.Configuration)
    .RegisterDataLayer()
    .RegisterBgWorkerLayer();

var host = builder.Build();
host.Run();
