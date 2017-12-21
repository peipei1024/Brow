using Brow.Txt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BrowLib.Register(new Utf8Txt());
            BrowLib.GetDefault().ReadAllTxt("");
        }
    }
}
