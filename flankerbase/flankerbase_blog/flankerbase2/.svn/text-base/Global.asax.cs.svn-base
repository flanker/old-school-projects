using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace flankerbaseNew
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                            // Route name
                "",                                                   // URL with parameters
                new { controller = "Home", action = "Index" }        // Parameter defaults
            );

            //routes.MapRoute(
            //    "Default",                                              // Route name
            //    "{controller}/{action}/{id}",                           // URL with parameters
            //    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            //);

            RegisterHomeRoutes(routes);

            RegisterAccountRoutes(routes);

            RegisterBlogsRoutes(routes);

            routes.MapRoute("Http404", "{*url}", new { controller = "Home", action = "Http404" });
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterHomeRoutes(RouteCollection routes)
        {
            routes.MapRoute("About", "About", new { controller = "Home", action = "About" });
        }

        private static void RegisterAccountRoutes(RouteCollection routes)
        {
            routes.MapRoute("LogOn", "LogOn", new { controller = "Account", action = "LogOn" });
            routes.MapRoute("LogOff", "LogOff", new { controller = "Account", action = "LogOff" });
        }

        private static void RegisterBlogsRoutes(RouteCollection routes)
        {
            routes.MapRoute("CreateComment", "Blogs/{key}/Comments/Create", new { controller = "Blogs", action = "CommentCreate" });
            routes.MapRoute("Blogs", "Blogs", new { controller = "Blogs", action = "Index" });
            routes.MapRoute("CreateBlog", "Blogs/Create", new { controller = "Blogs", action = "Create" });
            routes.MapRoute("UpdateBlog", "Blogs/{key}/Edit", new { controller = "Blogs", action = "Edit" });
            routes.MapRoute("DeleteBlog", "Blogs/{key}/Delete", new { controller = "Blogs", action = "Delete" });
            routes.MapRoute("Blog", "Blogs/{key}", new { controller = "Blogs", action = "Details" });
        }

    }
}