using DB.Lib;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlAgilityPackWindowsFormsApp1
{
    public class DataControl
    {
        public static List<string> GetCommmentList(string url)
        {
            List<string> list = new List<string>();
            if (url.StartsWith("http"))
            {
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);
                HtmlNode rootnode = document.DocumentNode;

                string xpathstring = @"/html[1]/body[1]/div[3]/div[3]/div[1]/div[@class='comment clearfix']/div[@class='comment_right fl']/div[2]";
                HtmlNodeCollection aa = rootnode.SelectNodes(xpathstring);
                for (int i = 0; i < aa.Count; i++)
                {
                    list.Add(aa[i].InnerText);
                }
            }
            return list;
        }

        public static int SaveComment(string comment, string tag, string type)
        {
            string sql = "insert into NT_Ai_Comment(comment, keyword, type) " +
                "values('" + comment + "', '" + tag + "', '" + type + "')";
            int k = DBLib.GetDefault().ExecuteCommand(sql);
            return k;
        }
    }
}
