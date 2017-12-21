using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brow.Txt
{
    public class BrowLib
    {
        private static BrowLib brow = null;
        private LogTxt logTxt = null;
        private Utf8Txt utf8txt = null;

        /// <summary>
        /// new LogTxt(int log_levenl, string p) 值越小越不记录
        /// new Utf8Txt()
        /// </summary>
        /// <param name="t"></param>
        public static void Register(object t)
        {
            brow = new BrowLib(t);
        }

       

        public static BrowLib GetDefault()
        {
            return brow;
        }

        private BrowLib(object t)
        {
            if (t.GetType() == typeof(LogTxt) && logTxt == null)
            {
                logTxt = (LogTxt)t;
            }
            if (t.GetType() == typeof(Utf8Txt) && utf8txt == null)
            {
                utf8txt = (Utf8Txt)t;
            }
        }

        

        public string ReadAllTxt(string path)
        {
            return utf8txt.ReadAllTxt(path);
        }
        public void Debug(string className, string content)
        {
            logTxt.Debug(className, content);
        }

        public void Info(string className, string content)
        {
            logTxt.Info(className, content);
        }

        public void Error(string className, string content)
        {
            logTxt.Error(className, content);
        }
    }
}
