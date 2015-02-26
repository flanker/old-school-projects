using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTimeSpace.Models;

namespace MvcTimeSpace.Controllers
{
    public class WorldController : Controller
    {
        //
        // GET: /World/
        private readonly WTimeRepository _repositorytime = new WTimeRepository();
        private readonly WRegionRepository _repositoryregion = new WRegionRepository();
        private readonly WCultureRepository _repositoryculture = new WCultureRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WRegion()
        {
            return View(_repositoryregion.GetAll());
        }

        public ActionResult WTime()
        {

            return View(_repositorytime.GetAll());
        }

        public ActionResult WTimeJson()
        {
            return View();  
        }
        public ActionResult WCulture()
        {
            return View(_repositoryculture.GetAll());
        }
    }
}
