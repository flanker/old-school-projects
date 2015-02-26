using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;

namespace DakkaWeb.Controllers
{
    public class ReportController : Controller
    {
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

    }
}
