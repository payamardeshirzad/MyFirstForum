using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstForum.Models;

namespace FirstForum.Controllers
{
    public class HomeController : Controller
    {
        PostDBContext _db=new PostDBContext();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
          //  var model = _db.Posts.ToList();
            //var model2 = _db.CategoryTopics
            //                .OrderBy(r => r.CatName)
            //                .Select(r=>new ShowCatTopic(){CategoryName = r.CatName,
            //                TopiceTitle = r.})
            var model = _db.CategoryTopics.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
