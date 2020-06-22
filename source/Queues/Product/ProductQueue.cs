namespace RabbitMQ.Queues
{
    public class ProductQueue : Queue<Product>, IProductQueue
    {
        public ProductQueue() : base("localhost") { }
    }
}
