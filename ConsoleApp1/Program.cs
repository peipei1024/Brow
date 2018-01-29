using Brow.SQL;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Brow.SQL lib库测试即使用
            //string configsql = "server=192.168.1.98;uid=sa;pwd=Qichang*(%123;database=qichang;";
            //string sql = "select top(1) * from nt_news order by id desc";
            //string sql1 = "INSERT INTO dbo.AppVers (VID,Ver,OperateType,CreateTime) VALUES " +
            //    "(0, N'中国', 0, GETDATE())";
            //List<string> list = new List<string>();
            //list.Add(sql1);
            //DataTable data;
            //EnumSQL enumSQL;

            //第一种调用方法
            //var factory = new SQLServerConnectionFactory();
            //factory.Register(configsql);
            //enumSQL = factory.GetDataTable(sql, out data);
            //enumSQL = factory.ExecuteCommand(sql1);
            //enumSQL = factory.ExecuteTran(list);
            //第一种调用方法的链式调用
            //Brow.SQL.IConnectionFactory fac = new SQLServerConnectionFactory();
            //enumSQL = fac.GetDefaultFactory(configsql).GetDataTable(sql, out data);


            //第二种调用方法
            //Brow.SQL.IConnectionFactory f = SQLServerConnectionFactory.GetDirectFactory(configsql);
            //enumSQL = f.GetDataTable(sql, out data);
            //enumSQL = f.ExecuteCommand(sql1);
            //第一种调用方法的链式调用
            //enumSQL = SQLServerConnectionFactory.GetDirectFactory(configsql).GetDataTable(sql, out data);


            //错误调用--抛出异常Brow.SQL.BrowException: 未初始化连接工厂
            //SQLServerConnectionFactory ss = new SQLServerConnectionFactory();
            //ss.GetDataTable(sql, out data);







            //var factory = new ConnectionFactory();
            //factory.HostName = "localhost";
            //factory.UserName = "guest";
            //factory.Password = "Qichang!@05";



            //string point = ".";
            //for(int i = 0; i < 50; i++)
            //{
            //    using (var connection = factory.CreateConnection())
            //    {
            //        using (var channel = connection.CreateModel())
            //        {
            //            channel.QueueDeclare("hello", false, false, false, null);
            //            string message = GetMessage(args);
            //            var properties = channel.CreateBasicProperties();
            //            properties.DeliveryMode = 2;
            //            point += ".";
            //            var body = Encoding.UTF8.GetBytes("hello" + i + point);
            //            channel.BasicPublish("", "hello", properties, body);
            //            Console.WriteLine(" set {0}", "hello" + i + point);
            //        }
            //    }
            //}



            Console.ReadKey();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
