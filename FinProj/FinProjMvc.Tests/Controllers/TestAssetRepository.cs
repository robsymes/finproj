using FinProjMvc.Dal;
using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Tests.Controllers
{
    public class TestAssetRepository : IAssetRepository
    {
        private string _username;

        public TestAssetRepository(string username)
        {
            _username = username;
        }

        public List<Asset> GetAssets()
        {
            return new List<Asset>
            {
                new Asset
                {
                    AssetId = 1,
                    Name = "Asset One",
                    Enabled = true,
                    Payments = new List<Payment>
                    { 
                        new Payment { Date = new DateTime(2010, 1, 1), Amount = 360.0M },
                        new Payment { Date = new DateTime(2011, 1, 1), Amount = 420.0M },
                        new Payment { Date = new DateTime(2012, 1, 1), Amount = 480.0M },
                    }
                },
                new Asset
                {
                    AssetId = 2,
                    Name = "Asset Two",
                    Enabled = true,
                    Payments = new List<Payment>
                    { 
                        new Payment { Date = new DateTime(2010, 1, 1), Amount = 200.0M },
                        new Payment { Date = new DateTime(2011, 1, 1), Amount = 300.0M },
                        new Payment { Date = new DateTime(2012, 1, 1), Amount = 400.0M },
                    }
                },
            };
        }


        public List<Credit> GetCredits()
        {
            return new List<Credit>();
        }

    }
}
