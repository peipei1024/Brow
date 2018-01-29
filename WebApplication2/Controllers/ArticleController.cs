using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            List<Article> list = new List<Article>();
            Article art = new Article();
            art.Newsid = "1000";
            art.Newstitle = "1000";
            art.Editor = "1000";
            art.Creattime = "1000";
            art.Status = "1000";
            list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art); list.Add(art);
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article art = new Article();
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View();
        }
    }
}