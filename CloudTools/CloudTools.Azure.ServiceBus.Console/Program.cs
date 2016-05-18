using Microsoft.ServiceBus.Messaging;
using System.Collections.Generic;

namespace CloudTools.Azure.ServiceBus.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var listenerConnString = "import string here";
            var speakerConnString = "import string here";

            var messageList = new List<BrokeredMessage>();
            messageList.Add(QueueUtils.GenerateBrokeredMessage("1", "First message information"));
            messageList.Add(QueueUtils.GenerateBrokeredMessage("2", "Second message information"));
            messageList.Add(QueueUtils.GenerateBrokeredMessage("3", "Third message information"));

            var queueListener = new QueueListener("TestQueue", listenerConnString, 4);
            var queueSpeaker = new QueueSpeaker("TestQueue", speakerConnString, 4);
            queueSpeaker.SendMessages(messageList);
            queueListener.ReceiveMessages();
            System.Console.ReadLine();

        }
    }
}
