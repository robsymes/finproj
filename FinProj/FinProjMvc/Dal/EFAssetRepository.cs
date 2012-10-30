using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinProjMvc.Dal
{
    public class EFAssetRepository : IAssetRepository
    {
        private string _username;
        private FinProjMvcContext db = new FinProjMvcContext();

        public EFAssetRepository(string username)
        {
            _username = username;
        }

        public List<Asset> GetList()
        {
            return db.Assets.Include("Payments").Where(a => a.Username == this._username).ToList();
        }

        public Asset Get(int id)
        {
            return db.Assets.Where(a => a.Username == this._username).SingleOrDefault(a => a.AssetId == id);
        }

        public void Insert(Asset asset)
        {
            asset.Username = this._username;
            db.Assets.Add(asset);
            db.SaveChanges();
        }

        public void Update(Asset asset)
        {
            asset.Username = this._username;
            db.Assets.Attach(asset);
            db.Entry(asset).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            // Checks here

            Asset asset = this.Get(id);
            Delete(asset);
        }

        public void Delete(Asset asset)
        {
            if (db.Entry(asset).State == EntityState.Detached)
            {
                db.Assets.Attach(asset);
            }
            db.Assets.Remove(asset);
            db.SaveChanges();
        }

    }
}