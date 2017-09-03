using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using FirstForum.Models;

namespace FirstForum.Controllers
{
    public class PostController : Controller
    {
        private PostDBContext db = new PostDBContext();

        //
        // GET: /Post/

        public ActionResult Index(string searchWord=null)
        {
            var model = db.Posts
                          .OrderBy(r => r.Title)
                          .Where(r => searchWord == null || r.Body.Contains(searchWord) || r.Title.Contains(searchWord))
                          .ToList();
            return View(model);
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id = 0)
        {
            PostModels postmodels = db.Posts.Find(id);
            if (postmodels == null)
            {
                return HttpNotFound();
            }
            return View(postmodels);
        }

        //
        // GET: /Post/Create
[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModels postmodels)
        {
            if (ModelState.IsValid)
            {
              CategoryTopic categoryTopic= db.CategoryTopics.Find(postmodels.CategoryId);
                postmodels.PosterName = User.Identity.Name;
                postmodels.DateSubmit = DateTime.Now.Date;
                categoryTopic.PostModelses.Add(postmodels);
             //   db.Posts.Add(postmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postmodels);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PostModels postmodels = db.Posts.Find(id);
            if (postmodels == null)
            {
                return HttpNotFound();
            }
            return View(postmodels);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostModels postmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postmodels);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PostModels postmodels = db.Posts.Find(id);
            if (postmodels == null)
            {
                return HttpNotFound();
            }
            return View(postmodels);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostModels postmodels = db.Posts.Find(id);
            db.Posts.Remove(postmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewAnswers(int id)
        {
            var post = db.Posts.Find(id);
            if (post != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateAnswer(int Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnswer(Answer answer)
        {
            if (ModelState.IsValid)
            {
                PostModels postmodel = db.Posts.Find(answer.Id);
                answer.PosModelsId = postmodel.Id;
                postmodel.Answers.Add(answer);
               // db.Answers.Add(answer);
                
                db.SaveChanges();
                return RedirectToAction("ViewAnswers",new{id=answer.PosModelsId});
            }
            return View(answer);
        }

        [HttpGet]
        public ActionResult AnswerPost(int id)
        {
            return View();
        }
    
  [HttpPost]      
        public ActionResult AnswerPost(Answer answer)
        {
            
            //Answer answer= new Answer();
            //answer.AnswerBody= "fsafdasdf";
            //answer.AnswerSender = User.Identity.Name;
            //answer.AnswerTopic = postmodels.Title;

            if (ModelState.IsValid)
            {
           
           //     answer.AnswerTopic = postmodels.Title;
                answer.AnswerSender = User.Identity.Name;
          //      answer.Id = postmodels.Id;
                db.Answers.Add(answer);
              //  postmodels.Answers.Add(answer);
               
                db.SaveChanges();
                return RedirectToAction("Index", new {id=answer.Id});
            }
            

            return View(answer);
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}