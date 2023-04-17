using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Practica.Api.GateWay.MessageHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot()
    .AddDelegatingHandler<PruebaUnoHandler>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

await app.UseOcelot();

app.Run();
