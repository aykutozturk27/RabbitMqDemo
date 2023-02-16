using RabbitMQ.Client;

namespace RabbitMqDemo.Core.Utilities.Adapter.RabbitMq
{
    public interface IRabbitMqConnectionAdapter
    {
        IConnection GetRabbitMqConnection();
        void SendMessage<T>(T entity);
        void GetMessage<T>(T entity);
    }
}
