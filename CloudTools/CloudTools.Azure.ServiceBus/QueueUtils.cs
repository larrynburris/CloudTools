using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudTools.Azure.ServiceBus
{
    public static class QueueUtils
    {
        public static BrokeredMessage GenerateBrokeredMessage(string messageId, string messageBody)
        {
            return new BrokeredMessage(messageBody)
                        {
                            MessageId = messageId
                        };
        }

        public static void HandleTransientErrors(MessagingException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Will retry sending the message in 2 seconds");
            Thread.Sleep(2000);
        }
    }
}
