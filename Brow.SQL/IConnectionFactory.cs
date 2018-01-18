using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.SQL
{
    public interface IConnectionFactory
    {
        void Register(string sqlpassword);
        IConnectionFactory GetDefault(string sqlServerPassword);
        IConnectionFactory GetDefault();
    }
}
