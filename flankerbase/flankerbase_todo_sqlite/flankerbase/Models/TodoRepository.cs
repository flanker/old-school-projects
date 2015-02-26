using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;

namespace flankerbase.Models
{
    public class TodoRepository
    {
        SQLiteConnection cnn;

        public TodoRepository()
        {
            //cnn = new SQLiteConnection(@"data source=G:\flanker\Dev\flankerbase\flankerbase3\flankerbase\App_Data\todo.s3db");

            cnn = new SQLiteConnection(@"data source=|DataDirectory|todo.s3db");
        }

        public List<Todo> GetAllTodos()
        {
            List<Todo> result = new List<Todo>();

            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = "select id, description, createdAt from todo order by createdAt desc";
            SQLiteDataReader reader = mycommand.ExecuteReader();

            while (reader.Read())
            {
                Todo tmp = new Todo(reader.GetInt32(0));
                tmp.Description = reader.GetString(1);
                tmp.CreatedAt = reader.GetDateTime(2);
                result.Add(tmp);
            }

            reader.Close();
            cnn.Close();

            return result;
        }

        public int AddTodo(Todo todo)
        {
            todo.DoValid();

            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = "insert into todo(description, createdAt) values(@description, @createdAt)";
            mycommand.Parameters.Add(new SQLiteParameter("@description", todo.Description));
            mycommand.Parameters.Add(new SQLiteParameter("@createdAt", todo.CreatedAt));

            int result = mycommand.ExecuteNonQuery();
            cnn.Close();

            return result;
        }
    }
}
