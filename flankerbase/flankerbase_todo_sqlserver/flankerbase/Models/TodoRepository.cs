using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace flankerbase.Models
{
    public class TodoRepository
    {
        SqlConnection conn;

        public TodoRepository()
        {
            conn = new SqlConnection(global::System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
        }

        public int GetAllCount()
        {
            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "select COUNT(id) "
                + "from todos "
                + "where isDeleted=0";
            int result = int.Parse(mycommand.ExecuteScalar().ToString());
            conn.Close();
            return result;
        }

        public int GetAllFinishCount()
        {
            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "select COUNT(id) "
                + "from todos "
                + "where isDeleted=0 and isFinished=1";
            int result = int.Parse(mycommand.ExecuteScalar().ToString());
            conn.Close();
            return result;
        }

        public Todo GetByID(int id)
        {
            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "select id, description, createdAt, isDeleted, deletedAt, isFinished, finishedAt "
                + "from todos "
                + "where isDeleted=0 and id=@id";
            mycommand.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = mycommand.ExecuteReader();

            if (reader.Read())
            {
                Todo tmp = new Todo(reader.GetInt32(0));
                tmp.Description = reader.GetString(1);
                tmp.CreatedAt = reader.GetDateTime(2);
                tmp.IsDeleted = reader.GetBoolean(3);
                tmp.DeletedAt = reader.GetSafeDateTime(4);
                tmp.IsFinished = reader.GetBoolean(5);
                tmp.FinishedAt = reader.GetSafeDateTime(6);
                reader.Close();
                conn.Close();
                return tmp;
            }
            else
            {
                reader.Close();
                conn.Close();
                return null;
            }
        }

        public List<Todo> GetAllTodos()
        {
            List<Todo> result = new List<Todo>();

            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "select id, description, createdAt, isFinished "
                + "from todos "
                + "where isDeleted=0 "
                + "order by createdAt desc";
            SqlDataReader reader = mycommand.ExecuteReader();

            while (reader.Read())
            {
                Todo tmp = new Todo(reader.GetInt32(0));
                tmp.Description = reader.GetString(1);
                tmp.CreatedAt = reader.GetDateTime(2);
                tmp.IsFinished = reader.GetBoolean(3);
                result.Add(tmp);
            }

            reader.Close();
            conn.Close();

            return result;
        }

        public List<Todo> GetRealAllTodos()
        {
            List<Todo> result = new List<Todo>();

            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "select id, description, createdAt, isFinished "
                + "from todos "
                + "order by createdAt desc";
            SqlDataReader reader = mycommand.ExecuteReader();

            while (reader.Read())
            {
                Todo tmp = new Todo(reader.GetInt32(0));
                tmp.Description = reader.GetString(1);
                tmp.CreatedAt = reader.GetDateTime(2);
                tmp.IsFinished = reader.GetBoolean(3);
                result.Add(tmp);
            }

            reader.Close();
            conn.Close();

            return result;
        }

        public int AddTodo(Todo todo)
        {
            todo.DoValid();

            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "insert into todos(description, createdAt, isDeleted, isFinished) "
                + "values(@description, @createdAt, 0, 0)";
            mycommand.Parameters.Add(new SqlParameter("@description", todo.Description));
            mycommand.Parameters.Add(new SqlParameter("@createdAt", todo.CreatedAt));

            int result = mycommand.ExecuteNonQuery();

            mycommand.CommandText= "select id, description, createdAt, isDeleted, deletedAt, isFinished, finishedAt "
                + "from todos "
                + "where description=@description1 and createdAt=@createdAt1";
            mycommand.Parameters.Add(new SqlParameter("@description1", todo.Description));
            mycommand.Parameters.Add(new SqlParameter("@createdAt1", todo.CreatedAt));
            SqlDataReader reader = mycommand.ExecuteReader();

            if (reader.Read())
            {
                todo.ID = reader.GetInt32(0);
            }

            reader.Close();
            conn.Close();

            return result;
        }

        public int DeleteTodo(int id)
        {
            Todo t = this.GetByID(id);
            if (t.IsFinished)
            {
                throw new Exception("不能删除已经完成的任务!");
            }

            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "update todos set isDeleted=@isDeleted, deletedAt=@deleteAt "
                + "where ID=@id";
            mycommand.Parameters.Add(new SqlParameter("@isDeleted", 1));
            mycommand.Parameters.Add(new SqlParameter("@deleteAt", DateTime.Now));
            mycommand.Parameters.Add(new SqlParameter("@id", id));

            int result = mycommand.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int FinishTodo(int id)
        {
            Todo t = this.GetByID(id);
            if (t.IsFinished)
            {
                throw new Exception("该任务已经完成了!");
            }

            conn.Open();
            SqlCommand mycommand = conn.CreateCommand();
            mycommand.CommandText = "update todos set isFinished=@isFinished, finishedAt=@finishedAt "
                + "where ID=@id";
            mycommand.Parameters.Add(new SqlParameter("@isFinished", 1));
            mycommand.Parameters.Add(new SqlParameter("@finishedAt", DateTime.Now));
            mycommand.Parameters.Add(new SqlParameter("@id", id));

            int result = mycommand.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public ProcessDTO GetProcess()
        {
            int allCount = GetAllCount();
            int allFinishCount = GetAllFinishCount();
            int i = (int)(((float)allFinishCount / allCount) * 100);
            string pricent = i.ToString() + "%";

            return new ProcessDTO()
            {
                AllCount = allCount,
                AllFinishCount = allFinishCount,
                Percent = pricent
            };
        }
    }

    public static class SqlDataReaderExtension
    {
        public static DateTime? GetSafeDateTime(this SqlDataReader reader, int i)
        {
            if (reader.GetSqlDateTime(i).IsNull)
            {
                return null;
            }
            else
            {
                return reader.GetDateTime(i);
            }
        }
    }
}
