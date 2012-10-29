﻿using FinProjMvc.Controllers;
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

            IAssetRepository repository = new TestAssetRepository("rob");
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

            IAssetRepository repository = new TestAssetRepository("rob");
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
