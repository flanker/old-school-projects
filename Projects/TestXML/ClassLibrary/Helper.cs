using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ClassLibrary
{
    public class Helper
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private XmlWriter writer;
        private XmlWriter Writer
        {
            get { return writer; }
            set { writer = value; }
        }


        private DataSchema schema;
        public DataSchema Schema
        {
            get { return schema; }
            set { schema = value; }
        }

        FileStream fs;
        ZipOutputStream s;
        ZipEntry ze;

        public Helper(string filePath)
        {
            this.filePath = filePath;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.GetEncoding("GB18030");

            fs = new FileStream(@"D:\test.zip", FileMode.Create, FileAccess.Write);

            s = new ZipOutputStream(fs);

            ze = new ZipEntry("aaa.xml");
            s.PutNextEntry(ze);

            this.writer = XmlWriter.Create(s, settings);
        }

        public void Begin()
        {
            Writer.WriteStartElement(Schema.DisplayName);
            Writer.Flush();
        }

        public void End()
        {
            Writer.WriteEndElement();
            Writer.Flush();
            Writer.Close();
            s.Close();
           
        }

        public void Write(string tableName, SqlDataReader reader)
        {
            DataSchemaTable table = Schema[tableName];

            Writer.WriteStartElement(table.DisplayName);

            while (reader.Read())
            {
                foreach (DataSchemaColumn column in table.Columns)
                {
                    Writer.WriteElementString(column.DisplayName, reader[column.FieldName].ToString());
                }

            }

            Writer.WriteEndElement();
            Writer.Flush();
        }
    }
}
