using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace NewsManagement.Controllers
{
    public class HomeController : Controller
    {
        private anmEntities db = new anmEntities();

        public ActionResult Index()
        {
            List<anm_News> news = db.anm_News.ToList();
            return View(news);
        }

        public ActionResult View(Int32 id)
        {
            var post = db.anm_News.SingleOrDefault(n => n.idnews == id);
            return View(post);
        }
        
        public ActionResult Edit(Int32 id)
        {
            anm_News anm_news = db.anm_News.Single(a => a.idnews == id);
            ViewBag.idcategory = new SelectList(db.anm_Categories, "idcategory", "category", anm_news.idcategory);
            return View(anm_news);
        }
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
        public ActionResult About()
        {
            return View();
        }
    }
}
