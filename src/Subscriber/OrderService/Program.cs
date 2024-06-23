using Core;
using Data;
using OrderService;
using OrderService.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterLogger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .RegisterCoreLayer(builder.Configuration)
    .RegisterDataLayer()
    .RegisterWebSubLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
