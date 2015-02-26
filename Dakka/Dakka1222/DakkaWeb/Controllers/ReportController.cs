using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaWeb.Filters;
using DakkaData;

namespace DakkaWeb.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            // Add action logic here
            throw new NotImplementedException();
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Test()
        {
            ViewData["Title"] = "Report";

            return View();
        }

        [Authorize]
        [ExceptionToViewFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Test(string EmployeeCode, string FromDate, string ToDate)
        {
            ViewData["Title"] = "Report2";

            ViewData["EmployeeCode"] = EmployeeCode;
            ViewData["FromDate"] = FromDate;
            ViewData["ToDate"] = ToDate;

            DateTime RealFromDate = DateTime.Parse(FromDate);
            DateTime RealToDate = DateTime.Parse(ToDate);

            List<WorkRecord.DTO> workRecordSome = WorkRecord.GetSome(EmployeeCode, RealFromDate, RealToDate);

            ViewData["Records"] = workRecordSome;

            return View();
        }

        [Authorize]
        public JsonResult GetSomeEmployeeRef()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);

            int employeeCount = Employee.GetAllCount();
            List<Employee.DTO> employeeSome = Employee.GetSome(start, limit);

            var result = new { totalProperty = employeeCount, root = employeeSome };

            return Json(result);
        }
    }
}
