using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData.Client;
using Google.GData.Photos;

namespace GooglePicasa.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            string user = "**********@gmail.com";

            PicasaService service = new PicasaService("PhotoBrowser");
            service.setUserCredentials(user, "**********");

            AlbumQuery query = new AlbumQuery();

            query.Uri = new Uri(PicasaQuery.CreatePicasaUri(user));

            PicasaFeed picasaFeed = service.Query(query);

            List<PicasaEntry> result = new List<PicasaEntry>();

            if (picasaFeed != null && picasaFeed.Entries.Count > 0)
            {
                foreach (PicasaEntry entry in picasaFeed.Entries)
                {
                    result.Add(entry);
                }
            }

            return View(result);
        }
    }
}
