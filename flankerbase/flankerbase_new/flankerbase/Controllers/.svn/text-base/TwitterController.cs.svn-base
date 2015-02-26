using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using flankerbase.Models;

namespace flankerbase.Controllers
{
    public class TwitterController : ControllerBase
    {
        TwitterRepository Repository = new TwitterRepository();

        //
        // GET: /Twitter/

        public ActionResult Index()
        {
            List<TwitterDTO> dtos = Repository.GetAll();

            return View(dtos);
        }

        //
        // GET: /m/Twitter/

        public ActionResult MobileIndex()
        {
            List<TwitterDTO> dtos = Repository.GetAll();

            return MobileView("Twitter", dtos);
        }

    }
}
