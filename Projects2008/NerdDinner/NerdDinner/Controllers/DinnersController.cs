using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NerdDinner.Models;
using NerdDinner.Helper;

namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        DinnerRepository dinnerRepository = new DinnerRepository();

        public ActionResult Index(int? page)
        {
            var dinners = dinnerRepository.FindUpcomingDinners(page);

            return View(dinners);
        }

        public ActionResult Details(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(dinner);
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            //ViewData["Countries"] = new SelectList(PhoneValidator.Countries, dinner.Country);

            //return View(dinner);

            return View(new DinnerFormViewModel(dinner));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            try
            {
                UpdateModel(dinner);

                dinnerRepository.Save();

                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            catch
            {
                ModelState.AddRuleViolations(dinner.GetRuleViolations());
                return View(new DinnerFormViewModel(dinner));
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
            {
                EventDate = DateTime.Now.AddDays(7)
            };
            return View(new DinnerFormViewModel(dinner));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Create(Dinner dinner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dinner.HostedBy = User.Identity.Name;

                    RSVP rsvp = new RSVP();
                    rsvp.AttendeeName = User.Identity.Name;
                    dinner.RSVPs.Add(rsvp);

                    dinnerRepository.Add(dinner);
                    dinnerRepository.Save();
                    return RedirectToAction("Details", new { id = dinner.DinnerID });
                }
                catch
                {
                    ModelState.AddRuleViolations(dinner.GetRuleViolations());
                    return View(new DinnerFormViewModel(dinner));
                }
            }
            return View(dinner);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            if (dinner == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(dinner);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Delete(int id, string confirmButton)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            if (dinner == null)
            {
                return View("NotFound");
            }
            dinnerRepository.Delete(dinner);
            dinnerRepository.Save();
            return View("Deleted");
        }
    }
}
