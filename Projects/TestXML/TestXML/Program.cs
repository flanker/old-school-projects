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
            columns1.Add(new DataSchemaColumn("描述", "Description"));
            columns1.Add(new DataSchemaColumn("创建时间", "CreatedAt"));
            tables.Add(new DataSchemaTable("单据类型", columns1));

            List<DataSchemaColumn> columns2 = new List<DataSchemaColumn>();
            columns2.Add(new DataSchemaColumn("标识", "ID"));
            columns2.Add(new DataSchemaColumn("描述", "Description"));
            columns2.Add(new DataSchemaColumn("创建时间", "CreatedAt"));
            tables.Add(new DataSchemaTable("单据明细表", columns1));



            DataSchema schema = new DataSchema("应收应付", tables);

            Helper helper = new Helper(@"D:\test.xml");
            helper.Schema = schema;

            helper.Begin();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
            conn.Open();

            SqlCommand com1 = conn.CreateCommand();
            com1.CommandText = "select * from todos";
            SqlDataReader reader1 = com1.ExecuteReader();
            helper.Write("单据类型", reader1);
            reader1.Close();

            SqlCommand com2 = conn.CreateCommand();
            com2.CommandText = "select * from todos";
            SqlDataReader reader2 = com2.ExecuteReader();
            helper.Write("单据明细表", reader2);
            reader2.Close();

            conn.Close();

            helper.End();

        }
    }
}
