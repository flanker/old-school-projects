using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;
using System.Collections.Specialized;

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
            int start = int.Parse(this.Request["start"]);
            int limit = int.Parse(this.Request["limit"]);

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
        public JsonResult AddNew()
        {
            string Code = this.Request["Code"];
            string Name = this.Request["Name"];
            string Email = this.Request["Email"];
            string Dept = this.Request["Dept"];

            if (Employee.IsEmployeeCodeExist(Code))
            {
                var re = new { success = false, msg = "The code '" + Code + "'exist. Please choose another one!" };
                return Json(re);
            }

            Employee.DTO head = new Employee.DTO()
            {
                Code = Code,
                Name = Name,
                Email = Email,
                Dept = Dept
            };

            Employee.AddNewEmployee(head);

            var resultSuccess = new { success = true, msg = "New employee saved!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult Update()
        {
            string Code = this.Request["Code"];
            string Name = this.Request["Name"];
            string Email = this.Request["Email"];
            string Dept = this.Request["Dept"];

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
        [ExceptionToViewFilter]
        public ActionResult Detail()
        {
            ViewData["Title"] = "Employee Detail";

            // 传递给客户端的隐藏字段
            NameValueCollection hidden = new NameValueCollection();
            hidden.Add("processID", HttpContext.Request["ID"]);
            ViewData["Hidden"] = hidden;

            return View();
        }

        [Authorize]
        public JsonResult GetByID()
        {
            string ID = this.Request["ID"];

            long realID = long.Parse(ID);

            var result = DakkaData.Employee.GetByID(realID);

            return Json(result);
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
