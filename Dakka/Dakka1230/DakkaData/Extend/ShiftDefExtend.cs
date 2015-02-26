using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DakkaData.Enums;

namespace DakkaData
{
    partial class ShiftDef
    {
        public static ShiftDef GetByCode(string Code)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.SingleOrDefault(sd => sd.Code == Code);

            return result;
        }

        public static int GetAllCount()
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.Count();

            return result;
        }

        public static List<ShiftDef.DTO> GetSome(int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.Select(sd => new DTO()
            {
                ID = sd.ID,
                Code = sd.Code,
                Name = sd.Name,
                Description = sd.Description,
                ShiftType = new ShiftTypeEnum(sd.ShiftType).Name
            }).Skip(start).Take(limit).ToList();

            return result;
        }

        public static void AddNewShiftDef(ShiftDef.DTO headDTO, List<ShiftPoint.DTO> lineDTOs)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            ShiftDef shiftDef = new ShiftDef
            {
                Code = headDTO.Code,
                Name = headDTO.Name,
                ShiftType = new ShiftTypeEnum(headDTO.ShiftType).Value,
                Description = headDTO.Description
            };

            foreach (var line in lineDTOs)
            {
                ShiftPoint shiftPoint = new ShiftPoint
                {
                    IndexNumber = line.IndexNumber,
                    Name = line.Name,
                    PointTime = DateTime.Parse(line.PointTime),
                    Before = int.Parse(line.Before),
                    After = int.Parse(line.After),
                    PointType = new PointTypeEnum(line.PointType).Value
                };

                shiftDef.ShiftPoint.Add(shiftPoint);
            }

            db.ShiftDef.InsertOnSubmit(shiftDef);

            db.SubmitChanges();
        }

        public static void UpdateShiftDef(ShiftDef.DTO headDTO, List<ShiftPoint.DTO> lineDTOs)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            ShiftDef shiftDef = db.ShiftDef.Single(sd => sd.ID == headDTO.ID);

            foreach (ShiftPoint point in shiftDef.ShiftPoint)
            {
                db.ShiftPoint.DeleteOnSubmit(point);
            }

            shiftDef.Code = headDTO.Code;
            shiftDef.Name = headDTO.Name;
            shiftDef.ShiftType = new ShiftTypeEnum(headDTO.ShiftType).Value;
            shiftDef.Description = headDTO.Description;

            foreach (var line in lineDTOs)
            {
                ShiftPoint shiftPoint = new ShiftPoint
                {
                    IndexNumber = line.IndexNumber,
                    Name = line.Name,
                    PointTime = DateTime.Parse(line.PointTime),
                    Before = int.Parse(line.Before),
                    After = int.Parse(line.After),
                    PointType = new PointTypeEnum(line.PointType).Value
                };

                shiftDef.ShiftPoint.Add(shiftPoint);
            }

            db.SubmitChanges();
        }

        public static void RemoveShiftDef(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.Single(em => em.ID == ID);

            foreach (var line in result.ShiftPoint)
            {
                db.ShiftPoint.DeleteOnSubmit(line);
            }

            db.ShiftDef.DeleteOnSubmit(result);

            db.SubmitChanges();
        }

        public static ShiftDef.DTO GetByID(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.SingleOrDefault(sd => sd.ID == ID);

            if (result == null)
            {
                throw new Exception("Can not find shiftDef by id: " + ID.ToString());
            }

            ShiftDef.DTO head = new ShiftDef.DTO()
            {
                Code = result.Code,
                Name = result.Name,
                Description = result.Description,
                ShiftType = new ShiftTypeEnum(result.ShiftType).Name,
                ShiftPoints = new List<ShiftPoint.DTO>()
            };

            foreach (var point in result.ShiftPoint)
            {
                var line = new ShiftPoint.DTO()
                {
                    IndexNumber = point.IndexNumber,
                    Name = point.Name,
                    Description = point.Description,
                    PointTime = point.PointTime.ToLongTimeString(),
                    Before = point.Before.ToString(),
                    After = point.After.ToString(),
                    PointType = new PointTypeEnum(point.PointType).Name
                };
                head.ShiftPoints.Add(line);
            }

            return head;
        }

        public static string GetNavPages(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            string first = "0";
            string prev = "0";
            string next = "0";
            string last = "0";

            var xfirst = db.ShiftDef.OrderBy(sd => sd.ID);
            if (xfirst.Count() > 0)
            {
                first = xfirst.First().ID.ToString();
            }

            var xprev = db.ShiftDef.Where(sd => sd.ID < ID).OrderByDescending(sd => sd.ID);
            if (xprev.Count() > 0)
            {
                prev = xprev.First().ID.ToString();
            }

            var xlast = db.ShiftDef.OrderByDescending(sd => sd.ID);
            if (xlast.Count() > 0)
            {
                last = xlast.First().ID.ToString();
            }

            var xnext = db.ShiftDef.Where(sd => sd.ID > ID).OrderBy(sd => sd.ID);
            if (xnext.Count() > 0)
            {
                next = xnext.First().ID.ToString();
            }

            return "[" + first + "," + prev + "," + next + "," + last + "]";
        }


        #region 默认DTO

        public struct DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ShiftType { get; set; }

            public List<ShiftPoint.DTO> ShiftPoints { get; set; }
        }

        #endregion

        #region 废弃代码

        //public static List<ShiftDef.DTO> GetAll()
        //{
        //    DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

        //    var result = db.ShiftDef.Select(sd => new DTO()
        //    {
        //        ID = sd.ID,
        //        Code = sd.Code,
        //        Name = sd.Name,
        //        Description = sd.Description,
        //        ShiftType = new ShiftTypeEnum(sd.ShiftType).Name
        //    }).ToList();

        //    return result;
        //}

        #endregion
    }
}
