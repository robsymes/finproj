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
    public class AssetController : Controller
    {
        //
        // GET: /Asset/

        public ActionResult Index()
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            return View(repository.GetList());
        }

        //
        // GET: /Asset/Details/5

        public ActionResult Details(int id = 0)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            Asset asset = repository.Get(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        //
        // GET: /Asset/Payments/5

        public ActionResult Payments(int id = 0)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            Asset asset = repository.Get(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        //
        // GET: /Asset/Create

        public ActionResult Create()
        {
            // return View();
            Asset asset = new Asset();
            return View(asset);
        }

        //
        // POST: /Asset/Create

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            if (ModelState.IsValid)
            {
                repository.Insert(asset);
                return RedirectToAction("Index");
            }

            return View(asset);
        }

        //
        // GET: /Asset/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            Asset asset = repository.Get(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        //
        // POST: /Asset/Edit/5

        [HttpPost]
        public ActionResult Edit(Asset asset)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            if (ModelState.IsValid)
            {
                repository.Update(asset);
                return RedirectToAction("Index");
            }
            return View(asset);
        }

        //
        // GET: /Asset/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            Asset asset = repository.Get(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        //
        // POST: /Asset/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
            Asset asset = repository.Get(id);
            repository.Delete(asset);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            // db.Dispose();
            base.Dispose(disposing);
        }
    }
}