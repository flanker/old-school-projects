using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using kaogu.Module;

namespace kaogu.MVC.Controllers
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

        public ActionResult Ref()
        {
            var projects = new XPQuery<Project>(DevExpress.Xpo.Session.DefaultSession);
            var refModel = new RefModel {Name = "Project"};
            refModel.Fields.Add("Name");
            refModel.Records = projects;

            return View(refModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }

    public class RefModel
    {
        public string Name { get; set; }
        private List<string> _fields =new List<string>();
        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public IEnumerable Records { get; set; }
    }
}