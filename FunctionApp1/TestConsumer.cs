using FunctionApp1.SharedContracts;
using FunctionApp1.SharedContracts.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public class TestConsumer : IConsumer<TestMessage>
    {
        public Task Consume(ConsumeContext<TestMessage> context)
        {
            throw new Exception("Ex");
            return Task.CompletedTask;
        }
    }
}