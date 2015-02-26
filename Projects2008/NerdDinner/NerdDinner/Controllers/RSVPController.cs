using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class RSVPController : Controller
    {
        DinnerRepository dinnerRepository = new DinnerRepository();

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (!dinner.IsUserRegistered(User.Identity.Name))
            {
                RSVP rsvp = new RSVP();
                rsvp.AttendeeName = User.Identity.Name;
                dinner.RSVPs.Add(rsvp);
                dinnerRepository.Save();
            }
            return Content("Thanks - we'll see you there!");
        }
    }
}
