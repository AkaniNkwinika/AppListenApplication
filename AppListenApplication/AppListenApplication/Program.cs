using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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
                HostName = "localhost", //Server Host
                UserName = "guest",     //Username
                Password = "guest",     //password
                Port = 15672            //port
            };

            //Connecting to the RabbitMQ server
            using(var connection = configConnection.CreateConnection())
            using (var virtualConnection = connection.CreateModel())
            {
                //Declare a queus
                virtualConnection.QueueDeclare(queue: "",
                    durable: true,
                    autoDelete: false,
                    arguments: null,
                    exclusive: false);

                var receiver = new EventingBasicConsumer(virtualConnection);
                receiver.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var firstName = message.Replace("Hello my name is,", "");
                    Console.WriteLine("Received message:" + message + "");
                    Console.WriteLine("Hello " + firstName + ",I am your father!");
                };
                //consume messages
                virtualConnection.BasicConsume(queue: "WongaAssessment", // Queue name
                    autoAck:true,// Auto-acknowledgment
                    consumer: receiver);

                Console.WriteLine("Listening for messages!!!!!!!");
                Console.ReadLine();
            }

        }
    }
}
