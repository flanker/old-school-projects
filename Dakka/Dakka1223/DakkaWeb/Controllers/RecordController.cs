using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;

namespace DakkaWeb.Controllers
{
    public class RecordController : Controller
    {
        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Make()
        {
            ViewData["Title"] = "Make Records";

            return View();
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Search()
        {
            ViewData["Title"] = "Search Records";

            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult DoMake()
        {

            string EmployeeCode = HttpContext.Request["EmployeeCode"];
            string WorkCalendarCode = HttpContext.Request["WorkCalendarCode"];
            string FromDateStr = HttpContext.Request["FromDate"];
            string ToDateStr = HttpContext.Request["ToDate"];

            DateTime FromDate = DateTime.Parse(FromDateStr);
            DateTime ToDate = DateTime.Parse(ToDateStr);

            WorkRecord.Make(EmployeeCode, WorkCalendarCode, FromDate, ToDate);

            var resultSuccess = new { success = true, msg = "Make records success!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetRecords()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);
            string employeeCode = HttpContext.Request["Employee"];
            DateTime fromDate = DateTime.Parse(HttpContext.Request["FromDate"]);
            DateTime toDate = DateTime.Parse(HttpContext.Request["ToDate"]);

            int workRecordCount = WorkRecord.GetAllCount(employeeCode, fromDate, toDate);
            List<WorkRecord.DTO> workRecordSome = WorkRecord.GetSome(employeeCode, fromDate, toDate, start, limit);

            var result = new { totalProperty = workRecordCount, root = workRecordSome };

            return Json(result);
        }

    }
}
