using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinProjMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            int currentYear = DateTime.Today.Year;
            int currentDecadeBaseYear = currentYear / 10 * 10;
            routes.MapRoute(
                name: "ProjectionDecade",
                url: "Projection/{action}/{year}",
                // defaults: new { controller = "Projection", action = "Decade", id = UrlParameter.Optional }
                defaults: new { controller = "Projection", action = "Decade", year = currentDecadeBaseYear }
            );

            routes.MapRoute(
                name: "ProjectionYear",
                url: "Projection/Year/{year}",
                // defaults: new { controller = "Projection", action = "Decade", id = UrlParameter.Optional }
                defaults: new { controller = "Projection", action = "Year", year = currentYear }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}