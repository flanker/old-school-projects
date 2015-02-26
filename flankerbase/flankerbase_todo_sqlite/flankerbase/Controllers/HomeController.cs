using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flankerbase.Models;

namespace flankerbase.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        TodoRepository repository = new TodoRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Todo()
        {
            List<Todo> todos = repository.GetAllTodos();

            return View(todos);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Todo(Todo todo)
        {
            try
            {
                todo.Description = todo.Description.Trim();
                todo.CreatedAt = DateTime.Now;

                repository.AddTodo(todo);

                return PartialView("aTodo", todo);
            }
            catch
            {
                Response.StatusCode = 400;
                return PartialView("aTodo", todo);
            }
        }
    }
}
