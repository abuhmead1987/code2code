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
    public class CategoryController : Controller
    {
        private anmEntities db = new anmEntities();

        //
        // GET: /Admin/Category/

        public ViewResult Index()
        {
            return View(db.anm_Categories.ToList());
        }

        //
        // GET: /Admin/Category/Details/5

        public ViewResult Details(int id)
        {
            anm_Categories anm_categories = db.anm_Categories.Single(a => a.idcategory == id);
            return View(anm_categories);
        }

        //
        // GET: /Admin/Category/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Category/Create

        [HttpPost]
        public ActionResult Create(anm_Categories anm_categories)
        {
            if (ModelState.IsValid)
            {
                db.anm_Categories.AddObject(anm_categories);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(anm_categories);
        }
        
        //
        // GET: /Admin/Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            anm_Categories anm_categories = db.anm_Categories.Single(a => a.idcategory == id);
            return View(anm_categories);
        }

        //
        // POST: /Admin/Category/Edit/5

        [HttpPost]
        public ActionResult Edit(anm_Categories anm_categories)
        {
            if (ModelState.IsValid)
            {
                db.anm_Categories.Attach(anm_categories);
                db.ObjectStateManager.ChangeObjectState(anm_categories, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anm_categories);
        }

        //
        // GET: /Admin/Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            anm_Categories anm_categories = db.anm_Categories.Single(a => a.idcategory == id);
            return View(anm_categories);
        }

        //
        // POST: /Admin/Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            anm_Categories anm_categories = db.anm_Categories.Single(a => a.idcategory == id);
            db.anm_Categories.DeleteObject(anm_categories);
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