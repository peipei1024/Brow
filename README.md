# Brow
Brow系列项目

目前只完成了SQL Server数据库的类库封装

```c#
Brow.SQL lib库使用
string configsql = "";
string sql = "";
string sql1 = "";
List<string> list = new List<string>();
list.Add(sql1);
DataTable data;
EnumSQL enumSQL;

//第一种调用方法
var factory = new SQLServerConnectionFactory();
factory.Register(configsql);
enumSQL = factory.GetDataTable(sql, out data);
enumSQL = factory.ExecuteCommand(sql1);
enumSQL = factory.ExecuteTran(list);

//第一种调用方法的链式调用
Brow.SQL.IConnectionFactory fac = new SQLServerConnectionFactory();
enumSQL = fac.GetDefaultFactory(configsql).GetDataTable(sql, out data);


//第二种调用方法
Brow.SQL.IConnectionFactory f = SQLServerConnectionFactory.GetDirectFactory(configsql);
enumSQL = f.GetDataTable(sql, out data);
enumSQL = f.ExecuteCommand(sql1);

//第二种调用方法的链式调用
enumSQL = SQLServerConnectionFactory.GetDirectFactory(configsql).GetDataTable(sql, out data);


//错误调用--抛出异常Brow.SQL.BrowException: 未初始化连接工厂
SQLServerConnectionFactory ss = new SQLServerConnectionFactory();
ss.GetDataTable(sql, out data);
```
