using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;
using System.Web.Security;
using System.Threading;
using HappyTogether.Models;
using System.Reflection;

namespace HappyTogether
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Together",
                "Together/Page/{page}",
                new { controller = "Together", action = "Index" }
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute("Root", "", new { controller = "Home", action = "Index", id = "" });

        }

        protected void Application_Start()
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Trace("******************** Application_Start ********************"
                + Environment.NewLine);

            RegisterRoutes(RouteTable.Routes);
        }

        //void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        //{
        //    // 获取当前User的引用
        //    IPrincipal usr = HttpContext.Current.User;

        //    // 如果当前用户通过认证, 并且是Forms认证
        //    if (usr.Identity.IsAuthenticated)
        //    {
        //        FormsIdentity fIdent = usr.Identity as FormsIdentity;

        //        // 基于当前票据创建一个XiaoneiIdentity
        //        HappyTogether.Helper.XiaoneiIdentity xi = new HappyTogether.Helper.XiaoneiIdentity(fIdent.Ticket);

        //        // 创建一个XiaoneiPrincipal          
        //        HappyTogether.Helper.XiaoneiPrincipal p = new HappyTogether.Helper.XiaoneiPrincipal(xi);

        //        // 附件到 HttpContext.User 和 Thread.CurrentPrincipal            
        //        HttpContext.Current.User = p;
        //        Thread.CurrentPrincipal = p;
        //    }
        //}

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