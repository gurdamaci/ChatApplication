using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessageLogService.Tools.DAL;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ChatApp.MessageLogService
{
    class MessageListener
    {
        public void DoWork()
        {
            try
            {
                new Thread(() =>
                {

                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "MessageLog",
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                    
                        while (true)
                        {
                            var consumer = new EventingBasicConsumer(channel);
                            consumer.Received += (model, ea) =>
                            {
                                var body = ea.Body.ToArray();
                                var data = Encoding.UTF8.GetString(body);
                                MessageLog messageLog = JsonConvert.DeserializeObject<MessageLog>(data);

                                //-------------------------
                                Mssql.SaveMessage(messageLog);
                            };
                            channel.BasicConsume(queue: "MessageLog",
                                                 autoAck: true,
                                                 consumer: consumer);

                        }

                    }
                }).Start();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}