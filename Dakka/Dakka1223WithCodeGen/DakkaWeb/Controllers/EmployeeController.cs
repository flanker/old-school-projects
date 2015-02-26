using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;

namespace DakkaWeb.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult List()
        {
            ViewData["Title"] = "Employee";

            return View();
        }

        [Authorize]
        public JsonResult GetSome()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);

            int employeeCount = Employee.GetAllCount();
            List<Employee.DTO> employeeSome = Employee.GetSome(start, limit);

            var result = new { totalProperty = employeeCount, root = employeeSome };

            return Json(result);
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult New()
        {
            ViewData["Title"] = "Add New Employee";

            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult New(string Code, string Name, string Email, string Dept)
        {
            if (Employee.IsEmployeeCodeExist(Code))
            {
                var re = new { success = false, msg = "The code '" + Code + "'exist. Please choose another one!" };
                return Json(re);
            }

            Employee.AddNewEmployee(Code, Name, Email, Dept);

            var resultSuccess = new { success = true, msg = "New employee saved!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult Edit(string Code, string Name, string Email, string Dept)
        {
            if (!Employee.IsEmployeeCodeExist(Code))
            {
                var re = new { success = false, msg = "The code '" + Code + "'do not exist. Please choose another one!" };
                return Json(re);
            }

            Employee.EditEmployee(Code, Name, Email, Dept);

            var resultSuccess = new { success = true, msg = "Employee updated!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult Remove()
        {
            string ID = HttpContext.Request["ID"];

            long removeID = long.Parse(ID);

            Employee.RemoveEmployee(removeID);

            var resultSuccess = new { success = true, msg = "Employee removed!" };

            return Json(resultSuccess);
        }
    }
}
