using FunctionApp1.SharedContracts;
using FunctionApp1.SharedContracts.Messages;
using MassTransit;
using System.Runtime.Serialization;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(o =>
{
    o.SetKebabCaseEndpointNameFormatter();

    o.AddConsumersFromNamespaceContaining<TestConsumer>();

    // A Transport
    o.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host("ConectionString");

        cfg.SubscriptionEndpoint<TestMessage>("testsub", e =>
        {
            e.ConfigureConsumer<TestConsumer>(context);
        });

        cfg.SubscriptionEndpoint<Fault<TestMessage>>("testsub-fault", e =>
        {
            e.ConfigureConsumer<TestConsumerFault>(context);
        });

        cfg.SubscriptionEndpoint<TestMessage>("testsubforfunc", e =>
        {
            e.ConfigureConsumers(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
