using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    [Serializable]
    public class BrowException: Exception
    {
        public BrowException() { }

        public BrowException(string message)
            : base(message)
        { }

        public BrowException(string message, Exception inner) 
            :base(message, inner)
        { }
    }
}
