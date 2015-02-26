using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace flankerbase
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "X",
                "Todo/X/{model}",
                new { controller = "Home", action = "X", model = "D" });

            routes.MapRoute(
                "Todo",
                "Todo",
                new { controller = "Home", action = "Todo" });

            routes.MapRoute(
                "All",
                "Todo/All",
                new { controller = "Home", action = "All" });

            routes.MapRoute(
                "Create",
                "Todo/Create",
                new { controller = "Home", action = "Create" });

            routes.MapRoute(
                "Delete",
                "Todo/Delete/{id}",
                new { controller = "Home", action = "Delete" });

            routes.MapRoute(
                "Finish",
                "Todo/Finish/{id}",
                new { controller = "Home", action = "Finish" });

            routes.MapRoute(
                "T",
                "Todo/T",
                new { controller = "Home", action = "T" });

            routes.MapRoute(
                "C",
                "Todo/C",
                new { controller = "Home", action = "C" });

            routes.MapRoute(
                "F",
                "Todo/F/{id}",
                new { controller = "Home", action = "F" });

            routes.MapRoute(
                "D",
                "Todo/D/{id}",
                new { controller = "Home", action = "D" });

            routes.MapRoute(
                "Default",
                "",
                new { controller = "Home", action = "Index" });

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}