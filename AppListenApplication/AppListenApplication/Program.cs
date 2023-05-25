using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListenApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

      
            var configConnection = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 15672
            };

            using(var connection = configConnection.CreateConnection())
            using (var virtualConnection = connection.CreateModel())
            {
                virtualConnection.QueueDeclare(queue: "",
                    durable: true,
                    autoDelete: false,
                    arguments: null,
                    exclusive: false);
            }

        }
    }
}
