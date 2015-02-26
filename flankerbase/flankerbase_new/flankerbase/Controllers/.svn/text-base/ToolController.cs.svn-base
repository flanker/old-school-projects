using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using flankerbase.Models;

namespace flankerbase.Controllers
{
    public class ToolController : ControllerBase
    {
        ToolRepository Repo = new ToolRepository();

        //
        // GET: /Tool/

        public ActionResult Index()
        {
            List<ToolDTO> result = Repo.GetAll();

            return View("Tool", result);
        }


        public ActionResult AjaxContent()
        {
            List<ToolDTO> result = Repo.GetAll();

            return PartialView("", result);
        }

        //
        // GET: /m/Tool/

        public ActionResult MobileIndex()
        {
            List<ToolDTO> result = Repo.GetAll();

            return MobileView("Tool", result);
        }

        //
        // GET: /Test/

        public ActionResult Test()
        {
            string r = Repo.GetTestString();

            ViewData["r"] = r;

            return View();
        }

    }
}
