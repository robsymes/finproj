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
            return View();
        }

        public ActionResult Year(int year)
        {
            ViewBag.PreviousYear = year - 1;
            ViewBag.Year = year;
            ViewBag.NextYear = year + 1;
            ViewBag.DecadeStartYear = year / 10 * 10;
            ViewBag.DecadeEndYear = year / 10 * 10 + 9;
            return View();
        }
    }
}
