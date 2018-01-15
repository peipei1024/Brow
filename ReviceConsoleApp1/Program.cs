using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReviceConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "guest";
            factory.Password = "Qichang!@05";
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        channel.QueueDeclare("hello", false, false, false, null);

            //        var consumer = new EventingBasicConsumer(channel);
            //        channel.BasicConsume("hello", false, consumer);
            //        consumer.Received += (model, ea) =>
            //        {
            //            var body = ea.Body;
            //            var message = Encoding.UTF8.GetString(body);
            //            Console.WriteLine("已接收： {0}", message);
            //        };
            //        channel.BasicConsume(queue: "hello",
            //                     autoAck: true,
            //                     consumer: consumer);
            //        Console.ReadLine();
            //    }
            //}


            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        channel.QueueDeclare("hello", false, false, false, null);

            //        var consumer = new QueueingBasicConsumer(channel);
            //        channel.BasicConsume("hello", true, consumer);

            //        while (true)
            //        {
            //            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

            //            var body = ea.Body;
            //            var message = Encoding.UTF8.GetString(body);

            //            int dots = message.Split('.').Length - 1;
            //            Thread.Sleep(dots * 1000);

            //            Console.WriteLine("Received {0}", message);
            //            Console.WriteLine("Done");
            //        }
            //    }
            //}


            Task.Factory.StartNew(() =>
            {
                
            });

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    


                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", false, consumer);
                    channel.BasicQos(0, 1, false);


                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);
                        channel.BasicAck(ea.DeliveryTag, false);

                        Console.WriteLine("Received {0}", message);
                        Console.WriteLine("Done");

                    }
                }
            }








        }
                
    }
}
