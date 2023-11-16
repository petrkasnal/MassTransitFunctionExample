using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using MassTransit;
using Microsoft.Azure.WebJobs;

namespace FunctionApp1
{
    public class Function1
    {
        const string TopicName = "functionapp1.sharedcontracts.messages/testmessage";
        const string SubscriptionName = "testsubforfunc";
        const string Connection = "AzureWebJobsStorage";
        private readonly IMessageReceiver _receiver;


        public Function1(IMessageReceiver receiver)
        {
            _receiver = receiver;
        }

        [Microsoft.Azure.Functions.Worker.Function(nameof(Function1))]
        public Task Run([Microsoft.Azure.Functions.Worker.ServiceBusTrigger(TopicName, SubscriptionName, Connection = Connection)] ServiceBusReceivedMessage message, CancellationToken cancellationToken)
        {
            return _receiver.HandleConsumer<TestConsumer>(TopicName, SubscriptionName, message, cancellationToken);
        }
    }
}
