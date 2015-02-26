using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HappyTogether.Models;
using HappyTogether.Helper;

namespace HappyTogether.Controllers
{
    public class JsonTogether
    {
        public int TogetherID { get; set; }
        public string Title { get; set; }
        public string TogetherType { get; set; }
        public string Description { get; set; }
        public string HostBy { get; set; }
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string Address { get; set; }
        public string PicURL { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int AttendeeCount { get; set; }
    }

    public class SearchController : AppControllerBase
    {

        // AJAX: /Search/SearchByLocation
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SearchByLocation(float longitude, float latitude, TogetherTypeWithAllEnum? togetherType)
        {
            var togethers = TogetherRepository.FindByLocation(latitude, longitude, togetherType ?? TogetherTypeWithAllEnum.All);
            var jsonTogethers = from together in togethers
                                select new JsonTogether
                                {
                                    TogetherID = together.TogetherID,
                                    Title = together.Title,
                                    TogetherType = together.TogetherTypeString,
                                    Description = together.Description,
                                    HostBy = together.HostedBy,
                                    UserName = together.UserName,
                                    StartDate = together.StartDate.ToString(),
                                    Address = together.Address,
                                    PicURL = together.PicURL,
                                    Latitude = together.Latitude,
                                    Longitude = together.Longitude,
                                    AttendeeCount = together.Attendees.Count
                                };
            return Json(jsonTogethers.ToList());
        }

    }
}
