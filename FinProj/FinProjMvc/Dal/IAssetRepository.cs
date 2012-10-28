using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Dal
{
    public interface IAssetRepository
    {
        List<Asset> GetAssets();
        List<Credit> GetCredits();

    }
}
