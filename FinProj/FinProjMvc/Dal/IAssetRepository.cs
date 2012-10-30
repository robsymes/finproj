using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Dal
{
    public interface IAssetRepository
    {
        List<Asset> GetList();
        Asset Get(int id);
        void Insert(Asset asset);
        void Update(Asset asset);
        void Delete(int id);
        void Delete(Asset asset);

    }
}
