using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using flankerbase.Models;
using flankerbase.Helpers;

namespace flankerbase.Controllers
{
    [HandleError]
    public class TodoController : ControllerBase
    {
        TodoRepository Repository = new TodoRepository();

        // for desktop

        [AcceptDevice(Device.Both)]
        public ActionResult Todo()
        {
            if (IsMobileDevice)
            {
                return RedirectToAction("T");
            }

            IList<Todo> todos = Repository.GetAllTodos();

            TodoDTO dto = new TodoDTO()
            {
                Process = Repository.GetProcess(),
                Todos = todos
            };
            return View("Todo", dto);
        }

        [AcceptDevice(Device.Desktop)]
        public ActionResult All()
        {
            IList<Todo> todos = Repository.GetRealAllTodos();

            TodoDTO dto = new TodoDTO()
            {
                Process = Repository.GetProcess(),
                Todos = todos
            };

            return View("Todo", dto);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Todo todo)
        {
            try
            {
                todo.Description = todo.Description.Trim();
                todo.CreatedAt = DateTime.Now;

                Repository.AddTodo(todo);

                TodoDTO dto = new TodoDTO()
                {
                    Process = Repository.GetProcess(),
                    Todos = Repository.GetAllTodos()
                };

                return PartialView("todos", dto);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            try
            {
                Repository.DeleteTodo(id);

                TodoDTO dto = new TodoDTO()
                {
                    Process = Repository.GetProcess(),
                    Todos = Repository.GetAllTodos()
                };

                return PartialView("todos", dto);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Finish(int id, FormCollection formValues)
        {
            try
            {
                Repository.FinishTodo(id);

                TodoDTO dto = new TodoDTO()
                {
                    Process = Repository.GetProcess(),
                    Todos = Repository.GetAllTodos()
                };

                return PartialView("todos", dto);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
        }

        // for mobile

        public ActionResult T()
        {
            try
            {
                IList<Todo> todos = Repository.GetAllTodos();

                TodoDTO dto = new TodoDTO()
                {
                    Process = Repository.GetProcess(),
                    Todos = todos
                };
                return MobileView("Todo", dto);
            }
            catch
            {
                return MobileView("Error");
            }
        }

        public ActionResult C()
        {
            return MobileView("Create");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult C(Todo todo)
        {
            try
            {
                todo.Description = todo.Description.Trim();
                todo.CreatedAt = DateTime.Now;

                Repository.AddTodo(todo);

                return RedirectToAction("T");
            }
            catch
            {
                return MobileView("Error");
            }
        }

        public ActionResult F(int id)
        {
            Todo todo = Repository.GetByID(id);

            return MobileView("Finish", todo);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult F(int id, FormCollection formValues)
        {
            try
            {
                Repository.FinishTodo(id);

                return RedirectToAction("T");
            }
            catch
            {
                return MobileView("Error");
            }
        }

        public ActionResult D(int id)
        {
            Todo todo = Repository.GetByID(id);

            return MobileView("Delete", todo);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult D(int id, FormCollection formValues)
        {
            try
            {
                Repository.DeleteTodo(id);

                return RedirectToAction("T");
            }
            catch
            {
                return MobileView("Error");
            }
        }

        public ActionResult X(string model)
        {
            if (String.IsNullOrEmpty(model))
            {
                return RedirectToAction("Todo");
            }
            else if (String.Equals(model, "D", StringComparison.CurrentCultureIgnoreCase))
            {
                HttpCookie cookie = new HttpCookie("model", "D");
                this.HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Todo");
            }
            else
            {
                HttpCookie cookie = new HttpCookie("model", "M");
                this.HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("T");
            }
        }

    }
}
