using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL.BrowException
{
    class NoConnectionException: Exception
    {
        public NoConnectionException()
        {

        }

    }

    class ConnectionCountException: Exception
    {
        public ConnectionCountException()
        {

        }
    }
}
