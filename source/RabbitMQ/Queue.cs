using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitMQ
{
    public abstract class Queue<T> : IQueue<T>
    {
        protected Queue(string hostName)
        {
            HostName = hostName;
        }

        private string HostName { get; }

        private string QueueName { get; } = typeof(T).Name;

        public void Publish(T obj)
        {
            Connection(channel => channel.BasicPublish(string.Empty, QueueName, null, obj.ToBytes()));
        }

        public void Subscribe(Action<T> action)
        {
            Connection(channel =>
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (_, args) => action(args.Body.ToBytes().ToObject<T>());
                channel.BasicConsume(QueueName, true, consumer);
                Console.ReadLine();
            });
        }

        private void Connection(Action<IModel> action)
        {
            using var connection = new ConnectionFactory { HostName = HostName }.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            action(channel);
        }
    }
}
