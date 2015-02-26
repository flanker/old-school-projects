using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    partial class WorkCalendar
    {
        public static List<WorkCalendar.DTO> GetAll()
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkCalendar.Select(wc => new DTO()
            {
                ID = wc.ID,
                Code = wc.Code,
                Name = wc.Name,
                Description = wc.Description,
                FromDate = wc.FromDate.HasValue ? wc.FromDate.GetValueOrDefault().ToShortDateString() : null,
                ToDate = wc.ToDate.HasValue ? wc.ToDate.GetValueOrDefault().ToShortDateString() : null
            }).ToList();

            return result;
        }

        public static List<WorkCalendar.DTO> GetSome(int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkCalendar.Select(wc => new DTO()
            {
                ID = wc.ID,
                Code = wc.Code,
                Name = wc.Name,
                Description = wc.Description,
                FromDate = wc.FromDate.HasValue ? wc.FromDate.GetValueOrDefault().ToShortDateString() : null,
                ToDate = wc.ToDate.HasValue ? wc.ToDate.GetValueOrDefault().ToShortDateString() : null
            }).Skip(start).Take(limit).ToList();

            return result;
        }

        public class DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
        }

    }
}
