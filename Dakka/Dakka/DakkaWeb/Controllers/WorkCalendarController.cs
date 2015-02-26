using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;
using DakkaWeb.Filters;
using Newtonsoft.Json.Linq;

namespace DakkaWeb.Controllers
{
    public class WorkCalendarController : Controller
    {
        [Authorize]
        public ActionResult List()
        {
            ViewData["Title"] = "WorkCalendar";

            return View();
        }

        [Authorize]
        public JsonResult GetSome()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);

            List<WorkCalendar.DTO> shiftDef = WorkCalendar.GetAll();
            List<WorkCalendar.DTO> shiftDefSome = WorkCalendar.GetSome(start, limit);

            var result = new { totalProperty = shiftDef.Count, root = shiftDefSome };

            return Json(result);
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult New()
        {
            ViewData["Title"] = "Add New WorkCalendar";

            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddNew()
        {
            string Code = HttpContext.Request["Code"];
            string Name = HttpContext.Request["Name"];
            string Description = HttpContext.Request["Description"];
            string FromDate = HttpContext.Request["FromDate"];
            string ToDate = HttpContext.Request["ToDate"];
            string Rules = HttpContext.Request["Rules"];

            List<string> ErrorList = new List<string>();

            if (string.IsNullOrEmpty(Code))
            {
                return Json(new { success = false, msg = "Code can not be empty!" });
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Json(new { success = false, msg = "Name can not be empty!" });
            }
            if (string.IsNullOrEmpty(Points))
            {
                return Json(new { success = false, msg = "Points param is null or empty!" });
            }

            ShiftDef.DTO head = new ShiftDef.DTO
            {
                Code = Code,
                Name = Name,
                ShiftType = string.IsNullOrEmpty(ShiftType) ? -1 : int.Parse(ShiftType),
                Description = Description
            };

            JObject json = JObject.Parse(Points);
            var result = from point in json["data"].Children()
                         select new ShiftPoint.DTO
                         {
                             IndexNumber = point.Value<int>("IndexNumber"),
                             Name = point.Value<string>("Name"),
                             PointTime = point.Value<string>("PointTime"),
                             PointType = point.Value<int>("PointType"),
                             Description = point.Value<string>("Description")
                         };

            ShiftDef.AddNewShiftDef(head, result.ToList());

            var resultSuccess = new { success = true, msg = "New shiftdef saved!" };

            return Json(resultSuccess);
        }
    }
}
