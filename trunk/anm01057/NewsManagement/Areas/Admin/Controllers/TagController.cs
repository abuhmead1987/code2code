using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsManagement;

namespace NewsManagement.Areas.Admin.Controllers
{ 
    public class TagController : Controller
    {
        private anmEntities db = new anmEntities();

        //
        // GET: /Admin/Tag/

        public ViewResult Index()
        {
            return View(db.anm_Tags.ToList());
        }

        //
        // GET: /Admin/Tag/Details/5

        public ViewResult Details(string id)
        {
            anm_Tags anm_tags = db.anm_Tags.Single(a => a.Tag == id);
            return View(anm_tags);
        }

        //
        // GET: /Admin/Tag/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Tag/Create

        [HttpPost]
        public ActionResult Create(anm_Tags anm_tags)
        {
            if (ModelState.IsValid)
            {
                db.anm_Tags.AddObject(anm_tags);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(anm_tags);
        }
        
        //
        // GET: /Admin/Tag/Edit/5
 
        public ActionResult Edit(string id)
        {
            anm_Tags anm_tags = db.anm_Tags.Single(a => a.Tag == id);
            return View(anm_tags);
        }

        //
        // POST: /Admin/Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(anm_Tags anm_tags)
        {
            if (ModelState.IsValid)
            {
                db.anm_Tags.Attach(anm_tags);
                db.ObjectStateManager.ChangeObjectState(anm_tags, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anm_tags);
        }

        //
        // GET: /Admin/Tag/Delete/5
 
        public ActionResult Delete(string id)
        {
            anm_Tags anm_tags = db.anm_Tags.Single(a => a.Tag == id);
            return View(anm_tags);
        }

        //
        // POST: /Admin/Tag/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            anm_Tags anm_tags = db.anm_Tags.Single(a => a.Tag == id);
            db.anm_Tags.DeleteObject(anm_tags);
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