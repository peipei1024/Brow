using Brow.SQL.BrowException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    class SQLServerLib
    {

        internal List<SqlConnection> connPool = new List<SqlConnection>();
        internal int connCount = 30;
        internal List<string> passwordList = new List<string>();

        internal SQLServerLib(int count, string sqlServerPassword)
        {
            this.connCount = count;
            InitConnPool(count, sqlServerPassword);
        }

        internal SQLServerLib(string sqlServerPassword)
        {
            InitConnPool(connCount, sqlServerPassword);
        }

        internal SQLServerLib(List<string> sqlServerPassword)
        {
            InitConnPool(sqlServerPassword);
        }


        private void InitConnPool(List<string> l)
        {
            this.passwordList = l;
            for (int i = 0; i < l.Count; i++)
            {
                SqlConnection con = new SqlConnection(l[i]);
                con.Open();
                connPool.Add(con);
            }
        }


        private SqlConnection GetConnection()
        {
            int a = 0;
            while (a < passwordList.Count)
            {
                if (connPool[a] == null)
                {
                    connPool[a] = new SqlConnection(passwordList[a]);
                    connPool[a].Open();
                    return connPool[a];
                }
                else if (connPool[a].State == ConnectionState.Closed)
                {
                    connPool[a].Open();
                    return connPool[a];
                }
                else if (connPool[a].State == ConnectionState.Broken)
                {
                    connPool[a].Close();
                    connPool[a].Open();
                    return connPool[a];
                }
                else if(connPool[a].State == ConnectionState.Executing)
                {

                }
                else if(connPool[a].State == ConnectionState.Fetching)
                {

                }
                else if(connPool[a].State == ConnectionState.Open)
                {
                    return connPool[a];
                }
                else if(connPool[a].State == ConnectionState.Connecting)
                {

                }
                a++;
            }
        }


        /// <summary>
        /// 初始化连接池
        /// </summary>
        /// <param name="count"></param>
        /// <param name="sqlServerPassword"></param>
        private void InitConnPool(int count, string sqlServerPassword)
        {
            for(int i = 0; i < count; i++)
            {
                SqlConnection con = new SqlConnection(sqlServerPassword);
                con.Open();
                connPool.Add(con);
            }
        }




        //private SqlConnection GetConnection()
        //{
        //    int a = 0;
        //    while (a < connCount)
        //    {
        //        if (connPool[a] == null)
        //        {
        //            connPool[a]
        //        }
        //        if (a > 15)
        //        {
        //            break;
        //        }
        //        a++;
        //    }
        //}

        private static SqlConnection connection;
        private static string connectionString = "";

        

        public DataTable GetDataTable(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        public int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int ExecuteSqlTran(List<string> SQLStringList)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            SqlTransaction tx = Connection.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
                return 1;
            }
            catch (Exception E)
            {
                tx.Rollback();
                return 2;
            }
        }


        //        /// <summary>
        //        /// 带参数的执行命令
        //        /// </summary>
        //        /// <param name="sql">SQL命令</param>
        //        /// <param name="values">返回VALUE值</param>
        //        /// <returns></returns>
        //        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            cmd.Parameters.AddRange(values);
        //            return cmd.ExecuteNonQuery();
        //        }
        //        /// <summary>
        //        /// 返回影响记录数
        //        /// </summary>
        //        /// <param name="safeSql"></param>
        //        /// <returns></returns>
        //        public static int GetScalar(string safeSql)
        //        {
        //            SqlCommand cmd = new SqlCommand(safeSql, Connection);
        //            int result = Convert.ToInt32(cmd.ExecuteScalar());
        //            return result;
        //        }
        //  
        //        public static int GetScalar(string sql, params SqlParameter[] values)
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            cmd.Parameters.AddRange(values);
        //            int result = Convert.ToInt32(cmd.ExecuteScalar());
        //            return result;
        //        }
        //  
        //        public static SqlDataReader GetReader(string safeSql)
        //        {
        //            SqlCommand cmd = new SqlCommand(safeSql, Connection);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            return reader;
        //        }
        //  
        //        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        //        {
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            cmd.Parameters.AddRange(values);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            return reader;
        //        }
        // 
        //       
        // 
        //        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        //        {
        //            DataSet ds = new DataSet();
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            cmd.Parameters.AddRange(values);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);
        //            return ds.Tables[0];
        //        }
        // 
        //        /// <summary>
        //        /// 获得数据集
        //        /// </summary>
        //        public static DataSet GetDataSet(string sql, string table)
        //        {
        //            DataSet ds = new DataSet();
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds, table);
        //            return ds;
        //        }
        // 
        //        public static DataSet GetDataSet(string sql, string table, params SqlParameter[] values)
        //        {
        //            DataSet ds = new DataSet();
        //            SqlCommand cmd = new SqlCommand(sql, Connection);
        //            cmd.Parameters.AddRange(values);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds, table);
        //            return ds;
        //        }
    }
}
