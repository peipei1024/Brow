using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "Qichang!@05";



            string point = ".";
            for(int i = 0; i < 50; i++)
            {
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("hello", false, false, false, null);
                        string message = GetMessage(args);
                        var properties = channel.CreateBasicProperties();
                        properties.DeliveryMode = 2;
                        point += ".";
                        var body = Encoding.UTF8.GetBytes("hello" + i + point);
                        channel.BasicPublish("", "hello", properties, body);
                        Console.WriteLine(" set {0}", "hello" + i + point);
                    }
                }
            }

            

            Console.ReadKey();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
