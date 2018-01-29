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
        private string connectionString = "";
        private SqlConnection con;

        internal SQLServerLib(string sqlServerPassword)
        {
            InitConnStr(sqlServerPassword);
        }

        private string InitConnStr(string sqlServerPassword)
        {
            this.connectionString = sqlServerPassword;
            return this.connectionString;
        }


        public SqlConnection Connection
        {
            get
            {
                if (con == null)
                {
                    con = new SqlConnection(connectionString);
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Broken)
                {
                    con.Close();
                    con.Open();
                }
                return con;
            }
        }

        public DataTable GetDataTable(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        

        public int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public void ExecuteSqlTran(List<string> SQLStringList)
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
            }
            catch (Exception E)
            {
                tx.Rollback();
                throw new BrowException(E.Message);
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
