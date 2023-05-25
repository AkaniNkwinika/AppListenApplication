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


        }
    }
}
