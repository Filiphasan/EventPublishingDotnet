using Core;
using Data;
using MainService;
using MainService.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterLogger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .RegisterCoreLayer(builder.Configuration)
    .RegisterDataLayer()
    .RegisterWebLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
