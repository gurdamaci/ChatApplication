using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ChatApp.ASPNETWinFormUI.RabbitMQ
{
    public static class RabbitMQPublisher
    {
        public static void SendMessage(Object log, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"

            };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string _messageLog = JsonConvert.SerializeObject(log);
                var    body        = Encoding.UTF8.GetBytes(_messageLog);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}