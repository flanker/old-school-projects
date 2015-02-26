using System.Configuration;
using System.Data.SQLite;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            StartExpressAppFramework();
        }

        private static void StartExpressAppFramework()
        {
            EditModelPermission.AlwaysGranted = Debugger.IsAttached;
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                    new SQLiteConnection(connectionString),
                    AutoCreateOption.DatabaseAndSchema);
            }
        }
    }
}