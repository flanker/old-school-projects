using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Npgsql;

namespace ProjectMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Project",
                            "Project/Index", new {controller = "Project", action = "Index"});
            routes.MapRoute("ProjectDetails",
                            "Project/{Code}", new {controller = "Project", action = "Detail", code = "Code"});
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitXpoConnection();
        }

        private static void InitXpoConnection()
        {
            EditModelPermission.AlwaysGranted = Debugger.IsAttached;
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                    new NpgsqlConnection(connectionString),
                    AutoCreateOption.DatabaseAndSchema);
            }
        }
    }
}