using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using kaogu_0730.Module;
using MvcWeb.Helpers;
using Npgsql;

namespace MvcWeb
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

            routes.MapRoute(
                "Project",
                "Project/{action}/{id}",
                new {controller = "Project", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Home",
                "",
                new { controller = "Home", action = "Index" }
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof(Project), new ProjectModelBinder());


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