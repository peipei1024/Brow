using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    class UnitTest
    {
        public void Index()
        {
            DataTable data;
            EnumSQL enumSQL;

            IConnectionFactory factory = new SQLServerConnectionFactory();
            factory.Register("192.168.1.98");
            enumSQL = factory.GetDataTable("sql", out data);

            IConnectionFactory fac = new SQLServerConnectionFactory();
            enumSQL = fac.GetDefaultFactory("192.168.1.98").GetDataTable("sql", out data);



            IConnectionFactory f = SQLServerConnectionFactory.GetDirectFactory("192.168.1.98");
            enumSQL = f.GetDataTable("sql", out data);

            enumSQL = SQLServerConnectionFactory.GetDirectFactory("192.168.1.98").GetDataTable("sql", out data);

            SQLServerConnectionFactory ss = new SQLServerConnectionFactory();
            ss.GetDataTable("sql", out data);


        }
    }
}
