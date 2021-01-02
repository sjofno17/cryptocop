using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class QueueService : IQueueService, IDisposable
    {
        private ConnectionFactory factory;
        private IConnection conn;
        private IModel channel;
        public void PublishMessage(string routingKey, object body)
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            conn = factory.CreateConnection();
            channel = conn.CreateModel();

            // Serialize the object to JSON
            var jsonString = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));

            channel.ExchangeDeclare("order", ExchangeType.Direct);
            channel.QueueDeclare("order", false, false, false, null);
            channel.QueueBind("order", "order", routingKey, null);
                
            // Publish the message using a channel created with the RabbitMQ client
            channel.BasicPublish(
                        exchange: "order",
                        routingKey: routingKey,
                         basicProperties: null,
                         body: jsonString);

        }

        public void Dispose()
        {
            channel.Close();
            conn.Close();
        }
    }
}