using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using System.Data.SqlClient;
using System.Configuration;

namespace TestXML
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataSchemaTable> tables = new List<DataSchemaTable>();

            List<DataSchemaColumn> columns1 = new List<DataSchemaColumn>();
            columns1.Add(new DataSchemaColumn("����", "Description"));
            columns1.Add(new DataSchemaColumn("����ʱ��", "CreatedAt"));
            tables.Add(new DataSchemaTable("��������", columns1));

            List<DataSchemaColumn> columns2 = new List<DataSchemaColumn>();
            columns2.Add(new DataSchemaColumn("��ʶ", "ID"));
            columns2.Add(new DataSchemaColumn("����", "Description"));
            columns2.Add(new DataSchemaColumn("����ʱ��", "CreatedAt"));
            tables.Add(new DataSchemaTable("������ϸ��", columns1));



            DataSchema schema = new DataSchema("Ӧ��Ӧ��", tables);

            Helper helper = new Helper(@"D:\test.xml");
            helper.Schema = schema;

            helper.Begin();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
            conn.Open();

            SqlCommand com1 = conn.CreateCommand();
            com1.CommandText = "select * from todos";
            SqlDataReader reader1 = com1.ExecuteReader();
            helper.Write("��������", reader1);
            reader1.Close();

            SqlCommand com2 = conn.CreateCommand();
            com2.CommandText = "select * from todos";
            SqlDataReader reader2 = com2.ExecuteReader();
            helper.Write("������ϸ��", reader2);
            reader2.Close();

            conn.Close();

            helper.End();

        }
    }
}
