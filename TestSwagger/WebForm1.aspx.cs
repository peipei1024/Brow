using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestSwagger
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string str_m = "";
        public Model m = new Model();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("拉布拉多");
            list.Add("萨摩耶");
            list.Add("塞罗纳");
            list.Add("边牧");
            list.Add("京巴");
            m.data = list;
            str_m = JsonConvert.SerializeObject(m);
        }


    }
    public class Model
    {
        public List<string> data;
    }
}