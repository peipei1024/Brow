using Brow.SQL.BrowException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    public class SQLServerConnectionFactory : IConnectionFactory
    {
        private SQLServerConnectionFactory factory = null;

        /// <summary>
        /// sql conection连接数
        /// </summary>
        private int sqlConnCount = 30;

        private Queue<>
        

        private SQLServerConnectionFactory(string sqlServerPassword)
        {
            this.factory = new SQLServerConnectionFactory(sqlServerPassword);
        }


        public IConnectionFactory GetDefault(string sqlServerPassword)

        {
            if (factory == null)
            {
                factory = new SQLServerConnectionFactory(sqlServerPassword);
            }
            return factory;
        }


        public IConnectionFactory GetDefault()
        {
            if (factory != null)
            {
                return factory;
            }
            else
            {
                throw new NoConnectionException();
            }
        }

        public void Register(string sqlpassword)
        {
            throw new NotImplementedException();
        }
    }
}
