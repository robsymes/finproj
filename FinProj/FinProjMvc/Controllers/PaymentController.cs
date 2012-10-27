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
    public class PaymentController : Controller
    {
        private FinProjMvcContext db = new FinProjMvcContext();

        //
        // GET: /Payment/

        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        //
        // GET: /Payment/Details/5

        public ActionResult Details(int id = 0)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // GET: /Payment/Create

        public ActionResult Create(int assetId)
        {
            ViewBag.AssetId = assetId;
            return View();
        }

        //
        // POST: /Payment/Create

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                // return RedirectToAction("Index");
                return RedirectToAction("Details", "Asset", new { id = payment.AssetId });
            }

            return View(payment);
        }

        //
        // GET: /Payment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /Payment/Edit/5

        [HttpPost]
        public ActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        //
        // GET: /Payment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /Payment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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