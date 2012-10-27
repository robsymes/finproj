using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinProjMvc.Dal
{
    public class EFAssetRepository : IAssetRepository
    {
        private FinProjMvcContext db = new FinProjMvcContext();

        public List<Asset> GetAssets()
        {
            return db.Assets.ToList();
        }
    }
}