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

            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
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

            IAssetRepository repository = new EFAssetRepository(User.Identity.Name);
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
