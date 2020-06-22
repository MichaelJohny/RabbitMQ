using RabbitMQ.Queues;
using System;

namespace RabbitMQ.Subscriber
{
    public static class Subscriber
    {
        public static void Main()
        {
            Console.WriteLine(nameof(Subscriber).ToUpper());

            IProductQueue productQueue = new ProductQueue();

            productQueue.Subscribe(product => Console.WriteLine(product.Name));

            Console.ReadLine();
        }
    }
}
