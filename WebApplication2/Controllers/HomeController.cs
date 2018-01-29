using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            aa();
            return View();
        }

        /// <summary>
        /// 使用新方法aanew()
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public string aa()
        {
            return "22";
        }


        public string aanew()
        {
            return "22";
        }
    }
}