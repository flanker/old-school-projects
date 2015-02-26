using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DakkaData
{
    partial class ShiftDef
    {

        /// <summary>
        /// 获得所有ShiftDef的List
        /// </summary>
        /// <returns></returns>
        public static List<ShiftDef.DTO> GetAll()
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.Select(sd => new DTO() { ID = sd.ID, Code = sd.Code, Name = sd.Name, Description = sd.Description, ShiftType = sd.ShiftType }).ToList();

            return result;
        }

        /// <summary>
        /// 获得指定范围的ShiftDef的List
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<ShiftDef.DTO> GetSome(int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.ShiftDef.Select(sd => new DTO() { ID = sd.ID, Code = sd.Code, Name = sd.Name, Description = sd.Description, ShiftType = sd.ShiftType }).Skip(start).Take(limit).ToList();

            return result;
        }

        public static void AddNewShiftDef(ShiftDef.DTO headDTO, List<ShiftPoint.DTO> lineDTOs)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            ShiftDef shiftDef = new ShiftDef
            {
                Code = headDTO.Code,
                Name = headDTO.Name,
                ShiftType = headDTO.ShiftType,
                Description = headDTO.Description
            };

            foreach (var line in lineDTOs)
            {
                ShiftPoint shiftPoint = new ShiftPoint
                {
                    IndexNumber = line.IndexNumber,
                    Name = line.Name,
                    PointTime = DateTime.Parse(line.PointTime),
                    PointType = line.PointType,
                };

                shiftDef.ShiftPoint.Add(shiftPoint);
            }

            db.ShiftDef.InsertOnSubmit(shiftDef);

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
                ShiftType = result.ShiftType,
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
                    PointType = point.PointType
                };
                head.ShiftPoints.Add(line);
            }

            return head;
        }

        /// <summary>
        /// 从数据库删除
        /// </summary>
        /// <param name="ID"></param>
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

        public struct DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? ShiftType { get; set; }

            public List<ShiftPoint.DTO> ShiftPoints { get; set; }
        }
    }
}
