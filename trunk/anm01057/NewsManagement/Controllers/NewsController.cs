using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsManagement;

namespace NewsManagement.Controllers
{ 
    public class NewsController : Controller
    {
        private anmEntities db = new anmEntities();

        //
        // GET: /News/

        public ViewResult Index()
        {
            var anm_news = db.anm_News.Include("anm_Categories");
            return View(anm_news.ToList());
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(int id)
        {
            anm_News anm_news = db.anm_News.Single(a => a.idnews == id);
            return View(anm_news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.idcategory = new SelectList(db.anm_Categories, "idcategory", "category");
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(anm_News anm_news)
        {
            if (ModelState.IsValid)
            {
                db.anm_News.AddObject(anm_news);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.idcategory = new SelectList(db.anm_Categories, "idcategory", "category", anm_news.idcategory);
            return View(anm_news);
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(int id)
        {
            anm_News anm_news = db.anm_News.Single(a => a.idnews == id);
            ViewBag.idcategory = new SelectList(db.anm_Categories, "idcategory", "category", anm_news.idcategory);
            return View(anm_news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(anm_News anm_news)
        {
            if (ModelState.IsValid)
            {
                db.anm_News.Attach(anm_news);
                db.ObjectStateManager.ChangeObjectState(anm_news, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategory = new SelectList(db.anm_Categories, "idcategory", "category", anm_news.idcategory);
            return View(anm_news);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(int id)
        {
            anm_News anm_news = db.anm_News.Single(a => a.idnews == id);
            return View(anm_news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            anm_News anm_news = db.anm_News.Single(a => a.idnews == id);
            db.anm_News.DeleteObject(anm_news);
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