using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HappyTogether.Models;
using HappyTogether.Helper;

namespace HappyTogether.Controllers
{
    public class AttendeeController : AppControllerBase
    {

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ContentResult Register(int id)
        {
            Together together = TogetherRepository.GetTogether(id);

            if (!together.IsUserRegistered(User.Identity.Name))
            {
                Attendee attendee = new Attendee();
                attendee.AttendeeBy = User.Identity.Name;
                attendee.UserName = User.Identity.UserName();
                attendee.TinyURL = User.Identity.TinyURL();
                together.Attendees.Add(attendee);
                TogetherRepository.Save();
            }
            return Content("Ð»Ð»£¬²»¼û²»É¢Å¶£¡");
        }
    }
}
