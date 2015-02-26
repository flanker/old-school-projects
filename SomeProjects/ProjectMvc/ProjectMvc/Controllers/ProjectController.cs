using System.Web.Mvc;
using ProjectMvc.Models;
using ProjectXAF.Module;

namespace ProjectMvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectRepository _repository = new ProjectRepository();

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public ActionResult Detail(string code)
        {
            var project = _repository.GetByCode(code);
            return View(project);
        }
    }
}
