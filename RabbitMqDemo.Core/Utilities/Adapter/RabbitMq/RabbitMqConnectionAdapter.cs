using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqDemo.Core.Utilities.Configuration;
using System.Text;

namespace RabbitMqDemo.Core.Utilities.Adapter.RabbitMq
{
    public class RabbitMqConnectionAdapter : IRabbitMqConnectionAdapter
    {
        private readonly string _hostName = CoreConfig.RammitMqHost;

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName= _hostName
            };
            return connectionFactory.CreateConnection();
        }

        public void SendMessage<T>(T entity)
        {
            using (var connection = GetRabbitMqConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare("product", exclusive: false);
                    string message = JsonConvert.SerializeObject(entity);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "product",
                                         body: body);
                }
            }
        }

        public void GetMessage<T>(T entity)
        {
            using (var connection = GetRabbitMqConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "product",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    var entityModel = entity;
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        entityModel = JsonConvert.DeserializeObject<T>(message);
                        Console.WriteLine($"Json received as {entityModel}");
                    };
                    channel.BasicConsume(queue: "product",
                                         consumer: consumer);
                }
            }
        }
    }
}
