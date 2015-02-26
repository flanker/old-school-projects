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


        /// <summary>
        /// 获得所有Employee的List
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetAll()
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.ToList();

            return result;
        }

        /// <summary>
        /// 获得所有Employee的List
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetSome(int start, int limit)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Select(em => em).Skip(start).Take(limit).ToList();

            return result;
        }

        /// <summary>
        /// 相同Code的Employee是否已经存在
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 添加一个Employee记录到数据库
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Dept"></param>
        public static void AddNewEmployee(string Code, string Name, string Email, string Dept)
        {
            Employee newEmployee = new Employee(Code, Name, Email, Dept);

            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            db.Employee.InsertOnSubmit(newEmployee);

            db.SubmitChanges();
        }

        /// <summary>
        /// 修改代码为Code的Employee记录
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Dept"></param>
        public static void EditEmployee(string Code, string Name, string Email, string Dept)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Single(em => em.Code == Code);

            result.Name = Name;
            result.Email = Email;
            result.Dept = Dept;

            db.SubmitChanges();
        }

        /// <summary>
        /// 从数据库删除指定的Employee
        /// </summary>
        /// <param name="ID"></param>
        public static void RemoveEmployee(long ID)
        {
            DakkaLinqDataContext db = DBHelper.GetDakkaLinqDataContext();

            var result = db.Employee.Single(em => em.ID == ID);

            db.Employee.DeleteOnSubmit(result);

            db.SubmitChanges();
        }
    }
}
