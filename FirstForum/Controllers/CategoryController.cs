using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstForum.Models;

namespace FirstForum.Controllers
{
    public class CategoryController : Controller
    {
        private PostDBContext db = new PostDBContext();

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(db.CategoryTopics.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            CategoryTopic categorytopic = db.CategoryTopics.Find(id);
            if (categorytopic == null)
            {
                return HttpNotFound();
            }
            return View(categorytopic);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryTopic categorytopic)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTopics.Add(categorytopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorytopic);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CategoryTopic categorytopic = db.CategoryTopics.Find(id);
            if (categorytopic == null)
            {
                return HttpNotFound();
            }
            return View(categorytopic);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryTopic categorytopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorytopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorytopic);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CategoryTopic categorytopic = db.CategoryTopics.Find(id);
            if (categorytopic == null)
            {
                return HttpNotFound();
            }
            return View(categorytopic);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTopic categorytopic = db.CategoryTopics.Find(id);
            db.CategoryTopics.Remove(categorytopic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}