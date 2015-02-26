using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class DataSchema
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private List<DataSchemaTable> tables;
        public List<DataSchemaTable> Tables
        {
            get { return tables; }
            set { tables = value; }
        }

        public DataSchema(string displayName)
        {
            this.displayName = displayName;
        }

        public DataSchema(string displayName, List<DataSchemaTable> tables)
        {
            this.displayName = displayName;
            this.tables = tables;
        }

        public DataSchemaTable this[string displayName]
        {
            get
            {
                foreach (DataSchemaTable table in Tables)
                {
                    if (table.DisplayName == displayName)
                    {
                        return table;
                    }
                }
                return null;
            }
        }
    }

    public class DataSchemaTable
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private List<DataSchemaColumn> columns;
        public List<DataSchemaColumn> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public DataSchemaTable(string displayName)
        {
            this.displayName = displayName;
        }

        public DataSchemaTable(string displayName, List<DataSchemaColumn> columns)
        {
            this.displayName = displayName;
            this.columns = columns;
        }

        public DataSchemaColumn this[string displayName]
        {
            get
            {
                foreach (DataSchemaColumn column in Columns)
                {
                    if (column.DisplayName == displayName)
                    {
                        return column;
                    }
                }
                return null;
            }
        }
    }

    public class DataSchemaColumn
    {
        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        public DataSchemaColumn(string displayName, string fieldName)
        {
            this.displayName = displayName;
            this.fieldName = fieldName;
        }
    }
}
