using FunctionApp1;
using MassTransit;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {

        services
         .AddScoped<Function1>()
         .AddMassTransitForAzureFunctions(cfg =>
         {
             cfg.AddConsumersFromNamespaceContaining<Function1>();
         }, "AzureWebJobsStorage");
    })
    .Build();

host.Run();
