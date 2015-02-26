using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;

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
                "Default",                                                      // Route name
                "{controller}.aspx/{action}/{id}",                              // URL with parameters
                new { controller = "Home", action = "Index", id = "" }          // Parameter defaults
            );

            routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = "" });

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public void Application_End()
        {
            HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember("_theRuntime",
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField, null, null, null);

            if (runtime == null)
                return;

            string shutDownMessage = (string)runtime.GetType().InvokeMember("_shutDownMessage",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField, null, runtime, null);

            string shutDownStack = (string)runtime.GetType().InvokeMember("_shutDownStack",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField, null, runtime, null);

            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Trace("******************** Application_End ********************" + Environment.NewLine
                + "ShutDownMessage: " + shutDownMessage + Environment.NewLine
                + "ShutDownStack: " + shutDownStack + Environment.NewLine);

        }
    }
}