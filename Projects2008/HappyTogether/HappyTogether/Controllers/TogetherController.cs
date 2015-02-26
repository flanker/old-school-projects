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
    public partial class TogetherController : AppControllerBase
    {
        // ��б�

        [ExceptionToViewFilter]
        public ActionResult Index(int? page)
        {
            var togethers = TogetherRepository.FindUpcomingTogethers(page);

            return View(togethers);
        }

        // ���ϸ

        [ExceptionToViewFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Together together = TogetherRepository.GetTogether(id.Value);

            // ����Form�õ�
            Post postForm = new Post();
            postForm.TogetherID = together.TogetherID;
            ViewData["PostForm"] = postForm;

            if (together == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(together);
            }
        }

        // ����

        [Authorize]
        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Details(Post post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    post.PostDate = DateTime.Now;
                    post.PostBy = User.Identity.Name;
                    post.UserName = User.Identity.UserName();
                    post.TinyURL = User.Identity.TinyURL();

                    TogetherRepository.AddPost(post);
                    TogetherRepository.Save();
                    return RedirectToAction("Details", new { id = post.TogetherID });
                }
                catch
                {
                    ModelState.AddRuleViolations(post.GetRuleViolations());
                }
            }
            ViewData["PostForm"] = post;
            return View(post.Together);
        }

        // ��ȡ�����Form

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Create()
        {
            Together together = new Together()
            {
                StartDate = DateTime.Now.AddDays(7)
            };
            return View(new TogetherFormViewModel(together));
        }

        // �����

        [Authorize]
        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Together together)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    together.HostedBy = User.Identity.Name;
                    together.TinyURL = User.Identity.TinyURL();
                    together.UserName = User.Identity.UserName();

                    Attendee attendee = new Attendee();
                    attendee.AttendeeBy = User.Identity.Name;
                    attendee.UserName = User.Identity.UserName();
                    attendee.TinyURL = User.Identity.TinyURL();
                    together.Attendees.Add(attendee);

                    TogetherRepository.Add(together);
                    TogetherRepository.Save();
                    return RedirectToAction("Details", new { id = together.TogetherID });
                }
                catch
                {
                    ModelState.AddRuleViolations(together.GetRuleViolations());
                    return View(new TogetherFormViewModel(together));
                }
            }
            return View(new TogetherFormViewModel(together));
        }

        // ��ȡ�޸ĻForm

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Edit(int id)
        {
            Together together = TogetherRepository.GetTogether(id);

            if (!together.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            return View(new TogetherFormViewModel(together));
        }

        // �޸Ļ

        [Authorize]
        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Together together = TogetherRepository.GetTogether(id);

            if (!together.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            try
            {
                UpdateModel(together);

                TogetherRepository.Save();

                return RedirectToAction("Details", new { id = together.TogetherID });
            }
            catch
            {
                ModelState.AddRuleViolations(together.GetRuleViolations());
                return View(new TogetherFormViewModel(together));
            }
        }

        // ��ȡɾ���Form

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Delete(int id)
        {
            Together together = TogetherRepository.GetTogether(id);

            if (!together.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            if (together == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(together);
            }
        }

        // ɾ���

        [Authorize]
        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            Together together = TogetherRepository.GetTogether(id);

            if (!together.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            if (together == null)
            {
                return View("NotFound");
            }
            TogetherRepository.Delete(together);
            TogetherRepository.Save();
            return View("Deleted");
        }


    }
}
