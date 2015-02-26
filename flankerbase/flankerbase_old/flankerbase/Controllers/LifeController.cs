using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using InsiderCoding.Twitter;

namespace flankerbase.Controllers
{
    [Title("life")]
    public class LifeController : AppControllerBase
    {

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string content)
        {
            Client client = new Client("########", "**********");
            User user = client.VerifyCredentials();
            if (user != null)
            {
                client.UpdateStatus(content);
            }

            return RedirectToAction("Index");
        }

    }
}
