using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using flankerbase2.Models;
using flankerbase2.Helpers;
using MvcContrib.Filters;
using System.ComponentModel;

namespace flankerbase2.Controllers
{
    [Rescue("../Error", typeof(Exception))]
    [Rescue("../Http404", typeof(flankerbase2.Helpers.Exceptions.BlogNotFoundException))]
    public class BlogsController : ApplicationController
    {

        //
        // GET: /Posts/

        public ActionResult Index([DefaultValue(1)]int page)
        {
            IQueryable<Blog> blogs = repo.FindAll().Paginate(page, 5, ViewData);

            return View(blogs);
        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(string key)
        {
            Blog blog = repo.FindByKey(key);

            ViewData["comment"] = new Comment { BlogID = blog.ID };

            return View(blog);
        }

        //
        // GET: /Posts/Create

        [Authorize]
        public ActionResult Create()
        {
            return View(new Blog());
        }

        //
        // POST: /Posts/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Create(blog);
                    return RedirectToAction("Details", new { key = blog.Code });
                }
                catch
                {
                    ModelState.AddRuleViolations(blog.GetRuleViolations());
                    return View(blog);
                }
            }
            return View(blog);
        }

        //
        // GET: /Posts/Edit/5

        [Authorize]
        public ActionResult Edit(string key)
        {
            return View(repo.FindByKey(key));
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(string key, FormCollection formValues)
        {
            Blog blog = repo.FindByKey(key);

            try
            {
                UpdateModel(blog);
                repo.Save();

                return RedirectToAction("Details", new { key = blog.Code });
            }
            catch
            {
                ModelState.AddRuleViolations(blog.GetRuleViolations());
                return View();
            }
        }

        //
        // POST: /Posts/5/Comments/Create

        [HttpPost]
        public ActionResult CommentCreate(Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Create(comment);
                    return RedirectToAction("Details", new { key = comment.Blog.Code });
                }
                catch
                {
                    ModelState.AddRuleViolations(comment.GetRuleViolations());
                    ViewData["comment"] = comment;
                    return View("Details", comment.Blog);
                }
            }

            return View("Details", comment.Blog);
        }

    }
}
