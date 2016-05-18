using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;

namespace CloudTools.Azure.ServiceBus
{
    public class QueueSpeaker
    {
        public string QueueName { get; private set; }
        public int MaxTrials { get; private set; }
        private QueueClient _queueClient;
        private readonly string _connectionString;

        public QueueSpeaker(string queueName, string connectionString, int maxTrials)
        {
            QueueName = queueName;
            MaxTrials = maxTrials;
            _queueClient = QueueClient.CreateFromConnectionString(connectionString);
        }

        public void SendMessages(IEnumerable<BrokeredMessage> messageList)
        {
            Console.WriteLine("Sending messages to queue {0}", QueueName);

            foreach (var message in messageList)
            {
                while (true)
                {
                    try
                    {
                        _queueClient.Send(message);
                    }
                    catch (MessagingException ex)
                    {
                        if (!ex.IsTransient)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                            throw;
                        }
                        else
                        {
                            QueueUtils.HandleTransientErrors(ex);
                        }
                        Console.WriteLine(string.Format("Message sent: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>()));
                        break;
                    }
                }
            }
        }
    }
}
