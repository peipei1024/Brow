using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
// 摘要:
//     Brow.SQL lib库测试即使用
//
// 第一种调用方法:
//     var factory = new SQLServerConnectionFactory();
//     factory.Register(configsql);
//     enumSQL = factory.GetDataTable(sql, out data);
//     enumSQL = factory.ExecuteCommand(sql1);
//     enumSQL = factory.ExecuteTran(list);
//
// 第一种调用方法的链式调用
//     Brow.SQL.IConnectionFactory fac = new SQLServerConnectionFactory();
//     enumSQL = fac.GetDefaultFactory(configsql).GetDataTable(sql, out data);
//
// 第二种调用方法
//     Brow.SQL.IConnectionFactory f = SQLServerConnectionFactory.GetDirectFactory(configsql);
//     enumSQL = f.GetDataTable(sql, out data);
//     enumSQL = f.ExecuteCommand(sql1);
//
// 第一种调用方法的链式调用
//     enumSQL = SQLServerConnectionFactory.GetDirectFactory(configsql).GetDataTable(sql, out data);
//
// 错误调用--抛出异常Brow.SQL.BrowException: 未初始化连接工厂
//     SQLServerConnectionFactory ss = new SQLServerConnectionFactory();
//     ss.GetDataTable(sql, out data);
//
// 返回结果:
//     EnumSQL是brow自定义的一个枚举集合
//
// 异常:
//   T:Brow.SQL.BrowException:
//     未初始化连接工厂。
//
// 说明:
//     configsql是sql server数据库的连接字符串
namespace Brow.SQL
{
    public interface IConnectionFactory
    {
        void Register(string sqlpassword);
        IConnectionFactory GetDefaultFactory(string sqlServerPassword);
        EnumSQL GetDataTable(string sql, out DataTable data);
        EnumSQL ExecuteCommand(string sql);
        EnumSQL ExecuteTran(List<string> list);

    }
}
