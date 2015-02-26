using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace DakkaData
{
    partial class Employee
    {
        public Employee(string Code, string Name, string Email, string Dept)
        {
            this.Code = Code;
            this.Name = Name;
            this.Email = Email;
            this.Dept = Dept;

            this._WorkRecord = new EntitySet<WorkRecord>(new Action<WorkRecord>(this.attach_WorkRecord), new Action<WorkRecord>(this.detach_WorkRecord));
            OnCreated();
        }

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
                ID= em.ID,
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

        public static void AddNewEmployee(string Code, string Name, string Email, string Dept)
        {
            Employee newEmployee = new Employee(Code, Name, Email, Dept);

            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            db.Employee.InsertOnSubmit(newEmployee);

            db.SubmitChanges();
        }

        public static void EditEmployee(string Code, string Name, string Email, string Dept)
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

        public class DTO
        {
            public long ID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Dept { get; set; }
        }
    }
}
