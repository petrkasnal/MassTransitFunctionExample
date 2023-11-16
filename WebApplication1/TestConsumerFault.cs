using FunctionApp1.SharedContracts;
using FunctionApp1.SharedContracts.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class TestConsumerFault : IConsumer<Fault<TestMessage>>
    {
        public Task Consume(ConsumeContext<Fault<TestMessage>> context)
        {
            return Task.CompletedTask;
        }
    }
}
