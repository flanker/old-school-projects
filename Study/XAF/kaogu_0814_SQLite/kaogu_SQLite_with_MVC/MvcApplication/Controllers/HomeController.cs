using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Xpo;
using kaogu_0730.Module;

namespace MvcApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var projects = new XPQuery<Project>(DevExpress.Xpo.Session.DefaultSession);

            var projectList = projects.ToList();

            return View(projectList);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string projectName)
        {
            var project = new Project
                              {
                                  Name = projectName
                              };
            project.Save();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}