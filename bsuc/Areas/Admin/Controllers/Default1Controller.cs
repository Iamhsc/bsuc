using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bsuc.Areas.Admin.Models;

namespace bsuc.Areas.Admin.Controllers
{
    public class Default1Controller : BaseController
    {
        private BsucConnectext db = new BsucConnectext();

        //
        // GET: /Admin/Default1/

        public ActionResult Index()
        {
            return View(db.bmenu.ToList());
        }

        //
        // GET: /Admin/Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            b_menu b_menu = db.bmenu.Find(id);
            if (b_menu == null)
            {
                return HttpNotFound();
            }
            return View(b_menu);
        }

        //
        // GET: /Admin/Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Default1/Create

        [HttpPost]
        public ActionResult Create(b_menu b_menu)
        {
            if (ModelState.IsValid)
            {
                db.bmenu.Add(b_menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(b_menu);
        }

        //
        // GET: /Admin/Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            b_menu b_menu = db.bmenu.Find(id);
            if (b_menu == null)
            {
                return HttpNotFound();
            }
            return View(b_menu);
        }

        //
        // POST: /Admin/Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(b_menu b_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(b_menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b_menu);
        }

        //
        // GET: /Admin/Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            b_menu b_menu = db.bmenu.Find(id);
            if (b_menu == null)
            {
                return HttpNotFound();
            }
            return View(b_menu);
        }

        //
        // POST: /Admin/Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            b_menu b_menu = db.bmenu.Find(id);
            db.bmenu.Remove(b_menu);
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