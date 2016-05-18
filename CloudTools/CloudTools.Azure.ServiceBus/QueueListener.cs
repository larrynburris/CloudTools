using Microsoft.ServiceBus.Messaging;
using System;

namespace CloudTools.Azure.ServiceBus
{
    public class QueueListener
    {
        public string QueueName { get; private set; }
        public int MaxTrials { get; private set; }
        private QueueClient _queueClient;

        public QueueListener(string queueName, string connectionString, int maxTrials)
        {
            QueueName = queueName;
            MaxTrials = maxTrials;
            _queueClient = QueueClient.CreateFromConnectionString(connectionString, QueueName, ReceiveMode.ReceiveAndDelete);

        }

        public void ReceiveMessages()
        {
            Console.WriteLine("Receiving message from queue {0}", QueueName);
            BrokeredMessage message = null;
            while (true)
            {
                try
                {
                    message = _queueClient.Receive(TimeSpan.FromSeconds(5));
                    if (message != null)
                    {
                        Console.WriteLine(string.Format("Message received: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>()));
                        //Add logic here
                        message.Complete();
                    }
                    else
                    {
                        //No messages in queue
                        break;
                    }
                }
                catch (MessagingException ex)
                {
                    if (!ex.IsTransient)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    else
                    {
                        QueueUtils.HandleTransientErrors(ex);
                    }
                }
            }
        }
    }
}
