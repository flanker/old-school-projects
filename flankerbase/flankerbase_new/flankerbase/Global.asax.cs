using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text.RegularExpressions;

namespace flankerbase
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Demo

            routes.MapRoute(
                "Demo",
                "demo",
                new { controller = "Demo", action = "Index" });

            routes.MapRoute(
                "MobileDemo",
                "m/demo",
                new { controller = "Demo", action = "MobileIndex" });

            routes.MapRoute(
                "Google_Chrome_Extension",
                "demo/google-chrome-extension",
                new { controller = "ClientCode", action = "Google_Chrome_Extension" });

            routes.MapRoute(
                "Http_Cache_And_Html5_Local_Storage",
                "demo/http_cache_and_html5_local_storage/{action}",
                new { controller = "Http_Cache_And_Html5_Local_Storage", action = "Index" });

            routes.MapRoute(
                "Javascript_Simple_3D_Tag_Cloud",
                "demo/javascript-simple-3d-tag-cloud",
                new { controller = "ClientCode", action = "Javascript_Simple_3D_Tag_Cloud" });

            routes.MapRoute(
                "Javascript_Snake_Game",
                "demo/javascript-snake-game",
                new { controller = "ClientCode", action = "Javascript_Snake_Game" });

            routes.MapRoute(
                "Redirect_Javascript_Snake_Game",
                "snake",
                new { controller = "ClientCode", action = "Redirect_Javascript_Snake_Game" });

            routes.MapRoute(
                "Pacific_War_Timeline_Map",
                "demo/pacific-war-timeline-map",
                new { controller = "ClientCode", action = "Pacific_War_Timeline_Map" });

            routes.MapRoute(
                "Redirect_Pacific_War_Timeline_Map",
                "pacificwar",
                new { controller = "ClientCode", action = "Redirect_Pacific_War_Timeline_Map" });

            #endregion

            #region Todo

            routes.MapRoute(
                "Todo",
                "todo",
                new { controller = "Todo", action = "Todo" });

            routes.MapRoute(
                "All",
                "todo/all",
                new { controller = "Todo", action = "All" });

            routes.MapRoute(
                "Create",
                "todo/create",
                new { controller = "Todo", action = "Create" });

            routes.MapRoute(
                "Delete",
                "todo/delete/{id}",
                new { controller = "Todo", action = "Delete" });

            routes.MapRoute(
                "Finish",
                "todo/finish/{id}",
                new { controller = "Todo", action = "Finish" });

            routes.MapRoute(
                "T",
                "todo/t",
                new { controller = "Todo", action = "T" });

            routes.MapRoute(
                "C",
                "todo/c",
                new { controller = "Todo", action = "C" });

            routes.MapRoute(
                "F",
                "todo/f/{id}",
                new { controller = "Todo", action = "F" });

            routes.MapRoute(
                "D",
                "todo/d/{id}",
                new { controller = "Todo", action = "D" });

            routes.MapRoute(
               "X",
               "todo/x/{model}",
               new { controller = "Todo", action = "X", model = "D" });

            #endregion

            #region twitter

            routes.MapRoute(
                "Twitter",
                "twitter",
                new { controller = "Twitter", action = "Index" });

            routes.MapRoute(
                "MobileTwitter",
                "m/twitter",
                new { controller = "Twitter", action = "MobileIndex" });

            #endregion

            #region tool

            routes.MapRoute(
                "Tool",
                "tool",
                new { controller = "Tool", action = "Index" });

            routes.MapRoute(
                "ToolAjax",
                "tool/ajaxContent",
                new { controller = "Tool", action = "AjaxContent" });

            routes.MapRoute(
                "MobileTool",
                "m/tool",
                new { controller = "Tool", action = "MobileIndex" });

            routes.MapRoute(
                "ToolTest",
                "tool/test",
                new { controller = "Tool", action = "Test" });

            #endregion

            #region home

            routes.MapRoute(
                "Social",
                "social",
                new { controller = "Home", action = "Social" });

            routes.MapRoute(
                "MobileAbout",
                "m/about",
                new { controller = "Home", action = "MobileAbout" });

            routes.MapRoute(
                "About",
                "about",
                new { controller = "Home", action = "About" });

            routes.MapRoute(
                "MobileHome",
                "m",
                new { controller = "Home", action = "MobileIndex" });

            routes.MapRoute(
                "Default",
                "",
                new { controller = "Home", action = "Index" });

            #endregion

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string hostName = Request.Headers["x-forwarded-host"];
            hostName = string.IsNullOrEmpty(hostName) ? Request.Url.Host : hostName;
            if (hostName == "www.chaojiwudi.com")
            {
                var builder = new UriBuilder(Request.Url)
                {
                    Host = "chaojiwudi.com"
                };
                string redirectUrl = builder.Uri.ToString();
                Response.Clear();
                Response.StatusCode = 301;
                Response.StatusDescription = "Moved Permanently";
                Response.AddHeader("Location", redirectUrl);
                Response.End();
            }
        }
    }
}