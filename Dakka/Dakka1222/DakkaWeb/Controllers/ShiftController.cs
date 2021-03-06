﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Script.Serialization;
using DakkaData;
using Newtonsoft.Json.Linq;
using DakkaWeb.Filters;
using System.Collections.Specialized;

namespace DakkaWeb.Controllers
{
    public class ShiftController : Controller
    {
        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult List()
        {
            ViewData["Title"] = "Shift def";

            return View();
        }

        [Authorize]
        public JsonResult GetAll()
        {
            List<ShiftDef.DTO> shiftDef = ShiftDef.GetAll();

            var result = new { totalProperty = shiftDef.Count, root = shiftDef };

            return Json(result);
        }

        [Authorize]
        public JsonResult GetSome()
        {
            int start = int.Parse(HttpContext.Request["start"]);
            int limit = int.Parse(HttpContext.Request["limit"]);

            List<ShiftDef.DTO> shiftDef = ShiftDef.GetAll();
            List<ShiftDef.DTO> shiftDefSome = ShiftDef.GetSome(start, limit);

            var result = new { totalProperty = shiftDef.Count, root = shiftDefSome };

            return Json(result);
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult New()
        {
            ViewData["Title"] = "Add New Shift def";

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
            string ShiftType = HttpContext.Request["ShiftType"];
            string Points = HttpContext.Request["Points"];

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
                ShiftType = ShiftType,
                Description = Description
            };

            JObject json = JObject.Parse(Points);
            var result = from point in json["data"].Children()
                         select new ShiftPoint.DTO
                         {
                             IndexNumber = point.Value<int>("IndexNumber"),
                             Name = point.Value<string>("Name"),
                             PointTime = point.Value<string>("PointTime"),
                             PointType = point.Value<string>("PointType"),
                             Description = point.Value<string>("Description")
                         };

            ShiftDef.AddNewShiftDef(head, result.ToList());

            var resultSuccess = new { success = true, msg = "New shiftdef saved!" };

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
            string ShiftType = HttpContext.Request["ShiftType"];
            string Points = HttpContext.Request["Points"];

            List<string> ErrorList = new List<string>();

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
            if (string.IsNullOrEmpty(Points))
            {
                return Json(new { success = false, msg = "Points param is null or empty!" });
            }

            ShiftDef.DTO head = new ShiftDef.DTO
            {
                ID = long.Parse(ID),
                Code = Code,
                Name = Name,
                ShiftType = ShiftType,
                Description = Description
            };

            JObject json = JObject.Parse(Points);
            var result = from point in json["data"].Children()
                         select new ShiftPoint.DTO
                         {
                             IndexNumber = point.Value<int>("IndexNumber"),
                             Name = point.Value<string>("Name"),
                             PointTime = point.Value<string>("PointTime"),
                             PointType = point.Value<string>("PointType"),
                             Description = point.Value<string>("Description")
                         };

            ShiftDef.UpdateShiftDef(head, result.ToList());

            var resultSuccess = new { success = true, msg = "Shiftdef updated!" };

            return Json(resultSuccess);
        }

        [Authorize]
        [ExceptionToViewFilter]
        public ActionResult Detail()
        {
            ViewData["Title"] = "Shift def Detail";

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

            var result = DakkaData.ShiftDef.GetByID(realID);

            return Json(result);
        }

        [Authorize]
        public JsonResult GetPoints()
        {
            string ID = HttpContext.Request["ID"];

            long realID = long.Parse(ID);

            var result = DakkaData.ShiftDef.GetByID(realID);

            return Json(new { totalProperty = result.ShiftPoints.Count, root = result.ShiftPoints });

        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [ExceptionToJsonFilter]
        public JsonResult Remove()
        {
            string ID = HttpContext.Request["ID"];

            long removeID = long.Parse(ID);

            ShiftDef.RemoveShiftDef(removeID);

            var resultSuccess = new { success = true, msg = "ShiftDef removed!" };

            return Json(resultSuccess);
        }
    }
}
