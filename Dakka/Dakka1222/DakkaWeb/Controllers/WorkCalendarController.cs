﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DakkaData;
using DakkaWeb.Filters;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace DakkaWeb.Controllers
{
    public class WorkCalendarController : Controller
    {
        [Authorize]
        [ExceptionToViewFilter]
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
        [ExceptionToJsonFilter]
        public JsonResult AddNew()
        {
            string Code = HttpContext.Request["Code"];
            string Name = HttpContext.Request["Name"];
            string Description = HttpContext.Request["Description"];
            string FromDate = HttpContext.Request["FromDate"];
            string ToDate = HttpContext.Request["ToDate"];
            string Rules = HttpContext.Request["Rules"];

            if (string.IsNullOrEmpty(Code))
            {
                return Json(new { success = false, msg = "Code can not be empty!" });
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Json(new { success = false, msg = "Name can not be empty!" });
            }

            WorkCalendar.DTO head = new WorkCalendar.DTO()
            {
                Code = Code,
                Name = Name,
                Description = Description,
                FromDate = FromDate,
                ToDate = ToDate
            };

            JObject json = JObject.Parse(Rules);
            var result = from rule in json["data"].Children()
                         select new WorkCalendarRule.DTO
                         {
                             RuleType = rule.Value<string>("RuleType"),
                             IsWorkDay = rule.Value<string>("IsWorkDay"),
                             Week = rule.Value<string>("Week"),
                             Year = rule.Value<string>("Year"),
                             Month = rule.Value<string>("Month"),
                             Day = rule.Value<string>("Day"),
                             Number = rule.Value<string>("Number"),
                             ShiftDef = rule.Value<string>("ShiftDef")
                         };
            WorkCalendar.AddNewWorkCalendar(head, result.ToList());

            var resultSuccess = new { success = true, msg = "New WorkCalendar saved!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult Update()
        {
            string ID = HttpContext.Request["ID"];
            string Code = HttpContext.Request["Code"];
            string Name = HttpContext.Request["Name"];
            string Description = HttpContext.Request["Description"];
            string FromDate = HttpContext.Request["FromDate"];
            string ToDate = HttpContext.Request["ToDate"];
            string Rules = HttpContext.Request["Rules"];

            if (string.IsNullOrEmpty(ID))
            {
                return Json(new { success = false, msg = "ID can not be empty!" });
            }
            if (string.IsNullOrEmpty(Code))
            {
                return Json(new { success = false, msg = "Code can not be empty!" });
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Json(new { success = false, msg = "Name can not be empty!" });
            }

            WorkCalendar.DTO head = new WorkCalendar.DTO()
            {
                ID = long.Parse(ID),
                Code = Code,
                Name = Name,
                Description = Description,
                FromDate = FromDate,
                ToDate = ToDate
            };

            JObject json = JObject.Parse(Rules);
            var result = from rule in json["data"].Children()
                         select new WorkCalendarRule.DTO
                         {
                             RuleType = rule.Value<string>("RuleType"),
                             IsWorkDay = rule.Value<string>("IsWorkDay"),
                             Week = rule.Value<string>("Week"),
                             Year = rule.Value<string>("Year"),
                             Month = rule.Value<string>("Month"),
                             Day = rule.Value<string>("Day"),
                             Number = rule.Value<string>("Number"),
                             ShiftDef = rule.Value<string>("ShiftDef")
                         };
            WorkCalendar.UpdateWorkCalendar(head, result.ToList());

            var resultSuccess = new { success = true, msg = "New WorkCalendar saved!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Detail()
        {
            ViewData["Title"] = "WorkCalendar Detail";

            // 传递给客户端的隐藏字段
            NameValueCollection hidden = new NameValueCollection();
            hidden.Add("processID", HttpContext.Request["ID"]);
            ViewData["Hidden"] = hidden;

            return View();
        }

        [Authorize]
        public JsonResult GetByID()
        {
            string ID = HttpContext.Request["ID"];

            long realID = long.Parse(ID);

            var result = DakkaData.WorkCalendar.GetByID(realID);

            return Json(result);
        }

        [Authorize]
        public JsonResult GetRules()
        {
            string ID = HttpContext.Request["ID"];

            long realID = long.Parse(ID);

            var result = DakkaData.WorkCalendar.GetByID(realID);

            return Json(new { totalProperty = result.WorkCalendarRules.Count, root = result.WorkCalendarRules });
        }

        [Authorize]
        public JsonResult GetSomeShiftDefRef()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);

            List<ShiftDef.DTO> shiftDef = ShiftDef.GetAll();
            List<ShiftDef.DTO> shiftDefSome = ShiftDef.GetSome(start, limit);

            var result = new { totalProperty = shiftDef.Count, root = shiftDefSome };

            return Json(result);
        }
    }
}