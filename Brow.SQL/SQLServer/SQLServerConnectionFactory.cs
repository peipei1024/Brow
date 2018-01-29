using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    public class SQLServerConnectionFactory : IConnectionFactory
    {
        private static SQLServerConnectionFactory factory = null;
        private readonly SQLServerLib lib;

        public SQLServerConnectionFactory()
        {

        }

        private SQLServerConnectionFactory(string sqlServerPassword)
        {
            if (lib == null)
            {
                lib = new SQLServerLib(sqlServerPassword);
            }
        }


        /// <summary>
        /// 直接获得sql server的工厂
        /// </summary>
        /// <param name="sqlServerPassword"></param>
        /// <returns></returns>
        public static IConnectionFactory GetDirectFactory(string sqlServerPassword)
        {
            if(factory == null)
            {
                factory = new SQLServerConnectionFactory(sqlServerPassword);
            }
            return factory;
        }

        

        /// <summary>
        /// 获得sql server的默认工厂
        /// </summary>
        /// <param name="sqlServerPassword"></param>
        /// <returns></returns>
        public IConnectionFactory GetDefaultFactory(string sqlServerPassword)

        {
            if (factory == null)
            {
                factory = new SQLServerConnectionFactory(sqlServerPassword);
            }
            return factory;
        }

        /// <summary>
        /// 注册sql server账号
        /// </summary>
        /// <param name="sqlServerPassword"></param>
        public void Register(string sqlServerPassword)
        {
            if(factory == null)
            {
                factory = new SQLServerConnectionFactory(sqlServerPassword);
            }
        }

        /// <summary>
        /// 通过sql语句进行查询，获得DataTable类型的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public EnumSQL GetDataTable(string sql, out DataTable data)
        {
            if (factory == null)
            {
                throw new BrowException("未初始化连接工厂");
            }
            else
            {
                try
                {
                    data = factory.lib.GetDataTable(sql);
                    if (data.Rows.Count == 0)
                    {
                        return EnumSQL.NoData;
                    }
                    else
                    {
                        return EnumSQL.Success;
                    }
                }
                catch (Exception E)
                {
                    throw new BrowException(E.Message);
                }
            }
        }

        /// <summary>
        /// 处理不需要结果集的sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public EnumSQL ExecuteCommand(string sql)
        {
            if (factory == null)
            {
                throw new BrowException("未初始化连接工厂");
            }
            else
            {
                try
                {
                    int k = factory.lib.ExecuteCommand(sql);
                    if (k == 1)
                    {
                        return EnumSQL.Success;
                    }
                    else
                    {
                        return EnumSQL.Error;
                    }
                }
                catch(Exception E)
                {
                    throw new BrowException(E.Message);
                }
                
            }

        }

        /// <summary>
        /// sql server事务处理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public EnumSQL ExecuteTran(List<string> list)
        {
            if(factory == null){
                throw new BrowException("未初始化连接工厂");
            }
            else
            {
                try
                {
                    factory.lib.ExecuteSqlTran(list);
                    return EnumSQL.Success;
                }
                catch(Exception E)
                {
                    throw new BrowException(E.Message);
                }
            }
        }

    }
}
