using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinProjMvc.Models;
using FinProjMvc.Dal;

namespace FinProjMvc.Controllers
{
    public class CreditController : Controller
    {
        //
        // GET: /Credit/

        public ActionResult Index()
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            return View(repository.GetList());
        }

        //
        // GET: /Credit/Details/5

        public ActionResult Details(int id = 0)
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            Credit credit = repository.Get(id);
            if (credit == null)
            {
                return HttpNotFound();
            }
            return View(credit);
        }

        //
        // GET: /Credit/Payments/5

        public ActionResult Payments(int id = 0)
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            Credit credit = repository.Get(id);
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
            //Credit credit = new Credit();
            //return View(credit);
        }

        //
        // POST: /Credit/Create

        [HttpPost]
        public ActionResult Create(Credit credit)
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            if (ModelState.IsValid)
            {
                repository.Insert(credit);
                return RedirectToAction("Index");
            }

            return View(credit);
        }

        //
        // GET: /Credit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            Credit credit = repository.Get(id);
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
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            if (ModelState.IsValid)
            {
                repository.Update(credit);
                return RedirectToAction("Index");
            }
            return View(credit);
        }

        //
        // GET: /Credit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            Credit credit = repository.Get(id);
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
            ICreditRepository repository = new EFCreditRepository(User.Identity.Name);
            Credit credit = repository.Get(id);
            repository.Delete(credit);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}
