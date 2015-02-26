using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DakkaData.Enums;

namespace DakkaData
{
    partial class WorkRecord
    {
        public static List<WorkRecord.DTO> GetFive(string EmployeeCode, DateTime Now)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkRecord.Where(wr => wr.Employee1.Code == EmployeeCode && wr.WorkPoint >= Now).OrderBy(wr => wr.WorkPoint).Take(3).Concat(
                db.WorkRecord.Where(wr => wr.Employee1.Code == EmployeeCode && wr.WorkPoint < Now).OrderByDescending(wr => wr.WorkPoint).Take(2));

            result = result.OrderBy(wr => wr.WorkPoint);

            List<WorkRecord.DTO> DTOs = new List<DTO>();

            foreach (var re in result)
            {
                DTO dto = new DTO();
                dto.ID = re.ID.ToString();
                dto.WorkPoint = re.WorkPoint.ToString();
                dto.PointType = new PointTypeEnum(re.PointType).Name;

                if (DateTime.Now < re.WorkPoint)
                {
                    dto.Status = "";
                }
                else
                {
                    if (re.Status == StatusEnum.OK.Value)
                    {
                        dto.Status = StatusEnum.OK.Name;
                    }
                    else
                    {
                        dto.Status = StatusEnum.Exception.Name;
                    }
                }

                DTOs.Add(dto);
            }

            return DTOs;
        }

        public static void DakkaByID(string ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            WorkRecord re = db.WorkRecord.Single(wr => wr.ID == long.Parse(ID));

            re.Status = StatusEnum.OK.Value;

            db.SubmitChanges();
        }

        public static void Make(string EmployeeCode, string WorkCalendarCode, DateTime FromDate, DateTime ToDate)
        {
            Employee employee = DakkaData.Employee.GetByCode(EmployeeCode);
            WorkCalendar workCalendar = DakkaData.WorkCalendar.GetByCode(WorkCalendarCode);

            long EmployeeID = employee.ID;

            List<WorkRecord> records = new List<WorkRecord>();

            do
            {
                bool isWorkDay = false;
                ShiftDef shiftDef = null;

                foreach (var rule in workCalendar.WorkCalendarRule)
                {
                    if (rule.RuleType == RuleTypeEnum.Week.Value)
                    {
                        if (rule.Week == new WeekEnum(FromDate.DayOfWeek.ToString()).Value)
                        {
                            isWorkDay = rule.IsWorkDay;
                            shiftDef = rule.ShiftDef1;
                        }
                    }
                    else if (rule.RuleType == RuleTypeEnum.Month.Value)
                    {
                        if (rule.Day == FromDate.Day)
                        {
                            isWorkDay = rule.IsWorkDay;
                            shiftDef = rule.ShiftDef1;
                        }
                    }
                    else if (rule.RuleType == RuleTypeEnum.Year.Value)
                    {
                        if (rule.Month == FromDate.Month && rule.Day == FromDate.Day)
                        {
                            isWorkDay = rule.IsWorkDay;
                            shiftDef = rule.ShiftDef1;
                        }
                    }
                    else if (rule.RuleType == RuleTypeEnum.Date.Value)
                    {
                        if (rule.Year == FromDate.Year
                            && rule.Month == FromDate.Month
                            && rule.Day == FromDate.Day)
                        {
                            isWorkDay = rule.IsWorkDay;
                            shiftDef = rule.ShiftDef1;
                        }
                    }
                }

                if (isWorkDay && shiftDef != null)
                {
                    foreach (var shiftPoint in shiftDef.ShiftPoint)
                    {
                        WorkRecord workRecord = new WorkRecord()
                        {
                            Employee = EmployeeID,
                            WorkPoint = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day,
                                shiftPoint.PointTime.Hour, shiftPoint.PointTime.Minute, shiftPoint.PointTime.Second),
                            PointType = shiftPoint.PointType,
                            Status = StatusEnum.Null.Value
                        };

                        records.Add(workRecord);
                    }
                }

                FromDate = FromDate.AddDays(1);
            }
            while (FromDate.Date <= ToDate);

            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            db.WorkRecord.InsertAllOnSubmit(records);

            db.SubmitChanges();
        }

        public static int GetAllCount(string EmployeeCode, DateTime FromDate, DateTime ToDate)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkRecord.Where(wr => wr.Employee1.Code == EmployeeCode && wr.WorkPoint >= FromDate && wr.WorkPoint <= ToDate).Count();

            return result;
        }

        public static List<WorkRecord.DTO> GetSome(string EmployeeCode, DateTime FromDate, DateTime ToDate, int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkRecord.Where(wr => wr.Employee1.Code == EmployeeCode && wr.WorkPoint >= FromDate && wr.WorkPoint <= ToDate).Skip(start).Take(limit)
                .Select(wr => new { WorkPoint = wr.WorkPoint, PointType = wr.PointType, Status = wr.Status }).ToList();

            List<WorkRecord.DTO> DTOs = new List<DTO>();

            foreach (var re in result)
            {
                DTO dto = new DTO();
                dto.WorkPoint = re.WorkPoint.ToString();
                dto.PointType = new PointTypeEnum(re.PointType).Name;


                if (re.Status == StatusEnum.OK.Value)
                {
                    dto.Status = StatusEnum.OK.Name;
                }

                else
                {
                    if (DateTime.Now < re.WorkPoint)
                    {
                        dto.Status = "";
                    }
                    else
                    {
                        dto.Status = StatusEnum.Exception.Name;
                    }
                }

                DTOs.Add(dto);
            }

            return DTOs;
        }

        public static List<WorkRecord.DTO> GetSome(string EmployeeCode, DateTime FromDate, DateTime ToDate)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkRecord.Where(wr => wr.Employee1.Code == EmployeeCode && wr.WorkPoint >= FromDate && wr.WorkPoint <= ToDate)
                .Select(wr => new { WorkPoint = wr.WorkPoint, PointType = wr.PointType, Status = wr.Status }).ToList();

            List<WorkRecord.DTO> DTOs = new List<DTO>();

            foreach (var re in result)
            {
                DTO dto = new DTO();
                dto.WorkPoint = re.WorkPoint.ToString();
                dto.PointType = new PointTypeEnum(re.PointType).Name;


                if (re.Status == StatusEnum.OK.Value)
                {
                    dto.Status = StatusEnum.OK.Name;
                }

                else
                {
                    if (DateTime.Now < re.WorkPoint)
                    {
                        dto.Status = "";
                    }
                    else
                    {
                        dto.Status = StatusEnum.Exception.Name;
                    }
                }

                DTOs.Add(dto);
            }

            return DTOs;
        }

        public class DTO
        {
            public string ID { get; set; }
            public string WorkPoint { get; set; }
            public string PointType { get; set; }
            public string Status { get; set; }
        }
    }
}