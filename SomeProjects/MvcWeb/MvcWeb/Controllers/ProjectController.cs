using System;
using System.Web.Mvc;
using kaogu_0730.Module;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectRepository _repository;

        public ProjectController()
        {
            _repository = new ProjectRepository();
        }

        //
        // GET: /Project/

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            _repository.Add(project);

            return RedirectToAction("Index");
        }

        //
        // GET: /Project/Details/id
        public ActionResult Details(string id)
        {
            var project = _repository.FindById(id);
            return View(project);
        }

        //
        // GET: /Project/Edit/id
        public ActionResult Edit(string id)
        {
            var project = _repository.FindById(id);
            return View(project);
        }

        //
        // POST: /Project/Edit/id

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            _repository.Update(project);
            return RedirectToAction("Index");
        }

        //
        // GET: /Project/Delete/id

        public ActionResult Delete(string id)
        {
            var project = _repository.FindById(id);
            return View(project);
        }

        //
        // POST: /Project/Delete/id

        [HttpPost]
        public ActionResult Delete(string id, string name)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
