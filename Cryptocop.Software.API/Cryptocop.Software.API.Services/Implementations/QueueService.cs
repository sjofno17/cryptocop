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
        public void PublishMessage(string routingKey, object body)
        {
            string jsonString = JsonConvert.SerializeObject(body);

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    
                    channel.BasicPublish(
                         exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
                }
            }
            Dispose();

        }

        public void Dispose()
        {
            // TODO: Dispose the connection and channel
            // is suppose to dispose of the current channel and connection associated with the service.

            //channel.Close();
            //conn.Close();
            throw new NotImplementedException();
        }
    }
}
/*
• PublishMessage =>  Serialize the object to JSON
                     Publish the message using a channel created with the RabbitMQ client
*/