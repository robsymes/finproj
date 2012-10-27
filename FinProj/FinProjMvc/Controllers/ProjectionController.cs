using FinProjMvc.Dal;
using FinProjMvc.Models;
using FinProjMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinProjMvc.Controllers
{
    public class ProjectionGenerator
    {
        // private FinProjMvcContext db = new FinProjMvcContext();
        private IAssetRepository assetRepository;

        public ProjectionGenerator(IAssetRepository repository)
        {
            assetRepository = repository;
        }

        public ProjectionViewModel GenerateProjection(List<DateTime> dateList, bool decade)
        {
            ProjectionViewModel viewModel = new ProjectionViewModel();
            viewModel.AssetRows = new List<RowViewModel>();
            // foreach (var asset in db.Assets)

            // List<decimal> cashFlowValues = new List<decimal>();
            Dictionary<DateTime, decimal> cashFlowValuesByDate = new Dictionary<DateTime, decimal>();
            foreach (var date in dateList)
            {
                cashFlowValuesByDate[date] = 0.00M;
            }
            foreach (var asset in assetRepository.GetAssets())
            {
                RowViewModel row = new RowViewModel
                {
                    Name = asset.Name,
                    LinkUrl = "/Asset/Details/" + asset.AssetId,
                    // LinkUrl = Url.Action("Details", "Asset", new { id = asset.AssetId })
                    Values = new List<decimal>()
                };
                foreach (var date in dateList)
                {                    
                    // If it's the decade view, total up the payment amounts for all the months in the year...
                    if (decade)
                    {
                        decimal total = 0.0M;
                        for (int m = 1; m <= 12; m++)
                        {
                            var individualMonthDate = new DateTime(date.Year, m, 1);
                            total += asset.MostRecentPaymentAmount(individualMonthDate);
                        }
                        row.Values.Add(total);
                        cashFlowValuesByDate[date] += total;
                    }
                    else
                    {
                        decimal amount = asset.MostRecentPaymentAmount(date);
                        row.Values.Add(amount);
                        cashFlowValuesByDate[date] += amount;
                    }

                }

                viewModel.AssetRows.Add(row);
            }

            viewModel.CashflowRow = new RowViewModel { Name = "Cashflow", Values = new List<decimal>() };
            foreach (var date in dateList)
            {
                viewModel.CashflowRow.Values.Add(cashFlowValuesByDate[date]);
            }
            viewModel.CashRow = new RowViewModel { Name = "Cash", Values = new List<decimal>() };

            decimal initialCash = 0.00M;
            decimal currentCash = initialCash;
            foreach (var date in dateList)
            {
                // currentCash += cashFlowValuesByDate[date];
                // Need to also take into account any credits/debits here
                viewModel.CashRow.Values.Add(currentCash);
            }

            return viewModel;
        }
    }

    public class ProjectionController : Controller
    {
        public ActionResult Decade(int year) // year = start year
        {
            ViewBag.PreviousYearStart = year - 10;
            ViewBag.PreviousYearEnd = year - 1;
            ViewBag.YearStart = year;
            ViewBag.YearEnd = year + 9;
            ViewBag.NextYearStart = year + 10;
            ViewBag.NextYearEnd = year + 19;

            IAssetRepository repository = new EFAssetRepository();
            ProjectionGenerator generator = new ProjectionGenerator(repository);
            List<DateTime> dateList = new List<DateTime>();
            for (int y = year; y < year + 10; y++)
            {
                dateList.Add(new DateTime(y, 1, 1));
            }
            ProjectionViewModel viewModel = generator.GenerateProjection(dateList, true);

            return View(viewModel);
        }

        public ActionResult Year(int year)
        {
            ViewBag.PreviousYear = year - 1;
            ViewBag.Year = year;
            ViewBag.NextYear = year + 1;
            ViewBag.DecadeStartYear = year / 10 * 10;
            ViewBag.DecadeEndYear = year / 10 * 10 + 9;

            IAssetRepository repository = new EFAssetRepository();
            ProjectionGenerator generator = new ProjectionGenerator(repository);
            List<DateTime> dateList = new List<DateTime>();
            for (int m = 1; m <= 12; m++)
            {
                dateList.Add(new DateTime(year, m, 1));
            }
            ProjectionViewModel viewModel = generator.GenerateProjection(dateList, false);

            return View(viewModel);
        }
    }
}
