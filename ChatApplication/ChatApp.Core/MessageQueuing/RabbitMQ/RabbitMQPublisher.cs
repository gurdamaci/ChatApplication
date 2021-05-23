using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ChatApp.Core.MessageQueuing.RabbitMQ
{
    /// <summary>
    /// İnterface' de static olarak tanımlayamadık ama methodu statik olarak uygulamış olduk.
    /// </summary>
    public class RabbitMQPublisher: IMQAdapter
    {
        public void SendMessage(Object obj, string queueuName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                RequestedConnectionTimeout = TimeSpan.FromMinutes(10)

            };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueuName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string _messageLog = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(_messageLog);

                channel.BasicPublish(exchange: "",
                                                 routingKey: queueuName,
                                                 basicProperties: null,
                                                 body: body);
            }
        }

        void IMQAdapter.SendMessage(object obj, string queueuName)
        {
            SendMessage(obj, queueuName);
        }
    }
}
