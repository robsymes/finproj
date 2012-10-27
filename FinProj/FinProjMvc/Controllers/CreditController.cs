using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinProjMvc.Models;

namespace FinProjMvc.Controllers
{
    public class CreditController : Controller
    {
        private FinProjMvcContext db = new FinProjMvcContext();

        //
        // GET: /Credit/

        public ActionResult Index()
        {
            return View(db.Credits.ToList());
        }

        //
        // GET: /Credit/Details/5

        public ActionResult Details(int id = 0)
        {
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        //
        // GET: /Credit/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Credit/Create

        [HttpPost]
        public ActionResult Create(Credit credit)
        {
            if (ModelState.IsValid)
            {
                db.Credits.Add(credit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credit);
        }

        //
        // GET: /Credit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        //
        // POST: /Credit/Edit/5

        [HttpPost]
        public ActionResult Edit(Credit credit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credit);
        }

        //
        // GET: /Credit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Credit credit = db.Credits.Find(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        //
        // POST: /Credit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Credit credit = db.Credits.Find(id);
            db.Credits.Remove(credit);
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