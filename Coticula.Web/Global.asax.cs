﻿using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Coticula.Web.Helpers;
using System.Web;

namespace Coticula.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Api", // Route name
                "{controller}/{action}.json", // URL with parameters and with format
                new { controller = "Home", action = "Index", format = "json" }
                );
            routes.MapRoute(
                "ApiWithParameters", // Route name
                "{controller}/{action}/{id}.json", // URL with parameters and with format
                new {controller = "Home", action = "Index", id = UrlParameter.Optional, format = "json"}
                );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            Database.SetInitializer(new CoticulaDbInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}