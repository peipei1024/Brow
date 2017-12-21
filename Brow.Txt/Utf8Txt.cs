using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.Txt
{
    public class Utf8Txt
    {
        public string ReadAllTxt(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            return streamReader.ReadToEnd();
        }
    }
}
