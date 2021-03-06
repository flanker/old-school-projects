﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace DakkaData
{
    partial class Employee
    {
        public static Employee GetByCode(string Code)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            if (!IsEmployeeCodeExist(Code))
            {
                throw new Exception("Can not find employee (Code: )" + Code);
            }

            var result = db.Employee.SingleOrDefault(em => em.Code == Code);

            return result;
        }

        public static int GetAllCount()
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Count();

            return result;
        }

        public static List<Employee.DTO> GetSome(int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Select(em => new DTO
            {
                ID = em.ID,
                Code = em.Code,
                Name = em.Name,
                Email = em.Email,
                Dept = em.Dept

            }).Skip(start).Take(limit).ToList();

            return result;
        }

        public static bool IsEmployeeCodeExist(string Code)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Count(em => em.Code == Code);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AddNewEmployee(Employee.DTO headDto)
        {
            Employee newEmployee = new Employee()
            {
                Code = headDto.Code,
                Name = headDto.Name,
                Email = headDto.Email,
                Dept = headDto.Dept
            };

            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            db.Employee.InsertOnSubmit(newEmployee);

            db.SubmitChanges();
        }

        public static void UpdateEmployee(string Code, string Name, string Email, string Dept)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Single(em => em.Code == Code);

            result.Name = Name;
            result.Email = Email;
            result.Dept = Dept;

            db.SubmitChanges();
        }

        public static void RemoveEmployee(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Single(em => em.ID == ID);

            db.Employee.DeleteOnSubmit(result);

            db.SubmitChanges();
        }

        public static Employee.DTO GetByID(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.SingleOrDefault(sd => sd.ID == ID);

            if (result == null)
            {
                throw new Exception("Can not find shiftDef by id: " + ID.ToString());
            }

            Employee.DTO head = new Employee.DTO()
            {
                ID = result.ID,
                Code = result.Code,
                Name = result.Name,
                Email = result.Email,
                Dept = result.Dept
            };

            return head;
        }

        public static string GetNavPages(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            string first = "0";
            string prev = "0";
            string next = "0";
            string last = "0";

            var xfirst = db.Employee.OrderBy(em => em.ID);
            if (xfirst.Count() > 0)
            {
                first = xfirst.First().ID.ToString();
            }

            var xprev = db.Employee.Where(em => em.ID < ID).OrderByDescending(em => em.ID);
            if (xprev.Count() > 0)
            {
                prev = xprev.First().ID.ToString();
            }

            var xlast = db.Employee.OrderByDescending(em => em.ID);
            if (xlast.Count() > 0)
            {
                last = xlast.First().ID.ToString();
            }

            var xnext = db.Employee.Where(em => em.ID > ID).OrderBy(em => em.ID);
            if (xnext.Count() > 0)
            {
                next = xnext.First().ID.ToString();
            }

            return "[" + first + "," + prev + "," + next + "," + last + "]";
        }


        #region 默认DTO

        public class DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Dept { get; set; }
        }

        #endregion
    }
}
