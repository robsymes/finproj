using FinProjMvc.Models;
using System;
using System.Collections.Generic;
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

        public List<Asset> GetAssets()
        {
            // return db.Assets.ToList();
            return db.Assets.Include("Payments").ToList();
        }

        // ////////////////////////////////////////////////////

        public List<Credit> GetCredits()
        {
            return db.Credits.ToList();
        }
    }
}