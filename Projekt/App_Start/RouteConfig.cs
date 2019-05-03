using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                "Login",
                "{controller}/{action}/{id}/{name}/{surname}",
                new { controller ="Login", action="GradeDetails", id = UrlParameter.Optional, name = UrlParameter.Optional, surname = UrlParameter.Optional});

            routes.MapRoute(
                 "Default",
                 "{controller}/{action}/{id}",
                 new { controller = "Customer", action = "Index", id = UrlParameter.Optional });
        }
    }
}
