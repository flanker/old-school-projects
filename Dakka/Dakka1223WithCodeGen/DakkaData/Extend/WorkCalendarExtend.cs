using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DakkaData.Enums;

namespace DakkaData
{
    partial class WorkCalendar
    {
        public static WorkCalendar GetByCode(string Code)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            if (!IsWorkCalendarCodeExist(Code))
            {
                throw new Exception("Can not find workCalendar (Code: )" + Code);
            }

            var result = db.WorkCalendar.SingleOrDefault(wc => wc.Code == Code);

            return result;
        }

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

        public static void AddNewWorkCalendar(WorkCalendar.DTO headDTO, List<WorkCalendarRule.DTO> lineDTOs)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            WorkCalendar workCalendar = new WorkCalendar
            {
                Code = headDTO.Code,
                Name = headDTO.Name,
                Description = headDTO.Description,
                //FromDate = DateTime.Parse(headDTO.FromDate),
                //ToDate = DateTime.Parse(headDTO.ToDate)
            };
            if (headDTO.FromDate != null)
            {
                workCalendar.FromDate = DateTime.Parse(headDTO.FromDate);
            }
            if (headDTO.ToDate != null)
            {
                workCalendar.ToDate = DateTime.Parse(headDTO.ToDate);
            }

            foreach (var line in lineDTOs)
            {
                WorkCalendarRule workCalendarRule = new WorkCalendarRule()
                {
                    RuleType = new RuleTypeEnum(line.RuleType).Value,
                    IsWorkDay = new IsWorkDayEnum(line.IsWorkDay).Value
                };

                if (line.Week != "" && line.Week != "null")
                {
                    workCalendarRule.Week = new WeekEnum(line.Week).Value;
                }
                if (line.Year != "" && line.Year != "null")
                {
                    workCalendarRule.Year = int.Parse(line.Year);
                }
                if (line.Month != "" && line.Month != "null")
                {
                    workCalendarRule.Month = int.Parse(line.Month);
                }
                if (line.Day != "" && line.Day != "null")
                {
                    workCalendarRule.Day = int.Parse(line.Day);
                }
                if (line.Number != "" && line.Number != "null")
                {
                    workCalendarRule.Number = int.Parse(line.Number);
                }
                if (line.ShiftDef != "" && line.ShiftDef != "null")
                {
                    ShiftDef sd = ShiftDef.GetByCode(line.ShiftDef);

                    if (sd != null)
                    {
                        workCalendarRule.ShiftDef = sd.ID;
                    }
                }

                workCalendarRule.RuleValue = "0";
                // TODO: 此处RuleValue在数据库中不能为空, 故先赋值, 待修改.

                workCalendar.WorkCalendarRule.Add(workCalendarRule);
            }

            db.WorkCalendar.InsertOnSubmit(workCalendar);

            db.SubmitChanges();
        }

        public static void UpdateWorkCalendar(WorkCalendar.DTO headDTO, List<WorkCalendarRule.DTO> lineDTOs)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            WorkCalendar workCalendar = db.WorkCalendar.Single(wc => wc.ID == headDTO.ID);

            workCalendar.Code = headDTO.Code;
            workCalendar.Name = headDTO.Name;
            workCalendar.Description = headDTO.Description;

            if (headDTO.FromDate != null)
            {
                workCalendar.FromDate = DateTime.Parse(headDTO.FromDate);
            }
            if (headDTO.ToDate != null)
            {
                workCalendar.ToDate = DateTime.Parse(headDTO.ToDate);
            }

            foreach (WorkCalendarRule rule in workCalendar.WorkCalendarRule)
            {
                db.WorkCalendarRule.DeleteOnSubmit(rule);
            }

            foreach (var line in lineDTOs)
            {
                WorkCalendarRule workCalendarRule = new WorkCalendarRule()
                {
                    RuleType = new RuleTypeEnum(line.RuleType).Value,
                    IsWorkDay = new IsWorkDayEnum(line.IsWorkDay).Value
                };

                if (line.Week != "" && line.Week != "null")
                {
                    workCalendarRule.Week = new WeekEnum(line.Week).Value;
                }
                if (line.Year != "" && line.Year != "null")
                {
                    workCalendarRule.Year = int.Parse(line.Year);
                }
                if (line.Month != "" && line.Month != "null")
                {
                    workCalendarRule.Month = int.Parse(line.Month);
                }
                if (line.Day != "" && line.Day != "null")
                {
                    workCalendarRule.Day = int.Parse(line.Day);
                }
                if (line.Number != "" && line.Number != "null")
                {
                    workCalendarRule.Number = int.Parse(line.Number);
                }
                if (line.ShiftDef != "" && line.ShiftDef != "null")
                {
                    ShiftDef sd = ShiftDef.GetByCode(line.ShiftDef);

                    if (sd != null)
                    {
                        workCalendarRule.ShiftDef = sd.ID;
                    }
                }

                workCalendarRule.RuleValue = "0";
                // TODO: 此处RuleValue在数据库中不能为空, 故先赋值, 待修改.

                workCalendar.WorkCalendarRule.Add(workCalendarRule);
            }

            db.SubmitChanges();
        }

        public static bool IsWorkCalendarCodeExist(string Code)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkCalendar.Count(wc => wc.Code == Code);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static WorkCalendar.DTO GetByID(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.WorkCalendar.SingleOrDefault(wc => wc.ID == ID);

            if (result == null)
            {
                throw new Exception("Can not find shiftDef by id: " + ID.ToString());
            }

            WorkCalendar.DTO head = new WorkCalendar.DTO()
            {
                Code = result.Code,
                Name = result.Name,
                Description = result.Description,
                FromDate = result.FromDate.HasValue ? result.FromDate.GetValueOrDefault().ToString("yyyy-MM-dd") : null,
                ToDate = result.ToDate.HasValue ? result.ToDate.GetValueOrDefault().ToString("yyyy-MM-dd") : null,
                WorkCalendarRules = new List<WorkCalendarRule.DTO>()
            };

            foreach (var rule in result.WorkCalendarRule)
            {
                var line = new WorkCalendarRule.DTO()
                {
                    RuleType = new RuleTypeEnum(rule.RuleType).Name,
                    IsWorkDay = rule.IsWorkDay.ToString(),
                    Week = new WeekEnum(rule.Week).Name,
                    Month = rule.Month.ToString(),
                    Year = rule.Year.ToString(),
                    Day = rule.Day.ToString(),
                    Number = rule.Number.ToString(),
                    ShiftDef = rule.ShiftDef.ToString()
                };
                head.WorkCalendarRules.Add(line);
            }

            return head;
        }

        public class DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }

            public List<WorkCalendarRule.DTO> WorkCalendarRules { get; set; }
        }

    }
}
