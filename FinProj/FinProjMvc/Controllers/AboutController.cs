﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinProjMvc.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            return View();
        }

    }
}
