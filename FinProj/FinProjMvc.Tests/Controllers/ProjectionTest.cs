using FinProjMvc.Controllers;
using FinProjMvc.Dal;
using FinProjMvc.Models;
using FinProjMvc.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinProjMvc.Tests.Controllers
{
    public class TestAssetRepository : IAssetRepository
    {
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
    }

    [TestClass]
    public class ProjectionTest
    {
        [TestMethod]
        public void DecadeProjection()
        {
            List<DateTime> dateList = new List<DateTime>
            {
                new DateTime(2010, 1, 1),
                new DateTime(2011, 1, 1),
                new DateTime(2012, 1, 1),
                new DateTime(2013, 1, 1),
            };

            IAssetRepository repository = new TestAssetRepository();
            ProjectionGenerator generator = new ProjectionGenerator(repository);
            ProjectionViewModel viewModel = generator.GenerateProjection(dateList, true);

            Assert.AreEqual(2, viewModel.AssetRows.Count);
            Assert.AreEqual(4, viewModel.AssetRows[0].Values.Count);
            Assert.AreEqual(4, viewModel.AssetRows[1].Values.Count);

            Assert.AreEqual(6720.0M, viewModel.CashflowRow.Values[0]);
            Assert.AreEqual(8640.0M, viewModel.CashflowRow.Values[1]);
            Assert.AreEqual(10560.0M, viewModel.CashflowRow.Values[2]);

        }

        [TestMethod]
        public void YearProjection()
        {
            List<DateTime> dateList = new List<DateTime>
            {
                new DateTime(2010, 1, 1),
                new DateTime(2011, 1, 1),
                new DateTime(2012, 1, 1),
                new DateTime(2012, 2, 1),
            };

            IAssetRepository repository = new TestAssetRepository();
            ProjectionGenerator generator = new ProjectionGenerator(repository);
            ProjectionViewModel viewModel = generator.GenerateProjection(dateList, false);

            Assert.AreEqual(2, viewModel.AssetRows.Count);
            Assert.AreEqual(4, viewModel.AssetRows[0].Values.Count);
            Assert.AreEqual(4, viewModel.AssetRows[1].Values.Count);

            Assert.AreEqual(560.0M, viewModel.CashflowRow.Values[0]);
            Assert.AreEqual(720.0M, viewModel.CashflowRow.Values[1]);
            Assert.AreEqual(880.0M, viewModel.CashflowRow.Values[2]);
            Assert.AreEqual(880.0M, viewModel.CashflowRow.Values[3]);

        }

    }
}
