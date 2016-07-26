using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MBODM.RateChar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Find", action = "Character", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Show",
                url: "{controller}/{action}/{realm}/{character}",
                defaults: new { controller = "Show", action = "Character", realm = string.Empty, character = string.Empty }
            );
        }
    }
}
