using RabbitMQ.Queues;
using System;

namespace RabbitMQ.Publisher
{
    public static class Publisher
    {
        public static void Main()
        {
            Console.WriteLine(nameof(Publisher).ToUpper());

            while (true)
            {
                Console.Write("Enter the product name: ");

                var name = Console.ReadLine();

                var product = new Product { Name = name };

                IProductQueue productQueue = new ProductQueue();

                productQueue.Publish(product);
            }
        }
    }
}
