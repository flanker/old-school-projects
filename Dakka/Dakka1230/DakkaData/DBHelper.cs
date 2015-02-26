using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DakkaData
{
    public class DBHelper
    {
        private const string ConnectionStringName = "TestConnectionString";

        public static DakkaLinqDataContext GetDakkaLinqDataContext()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

            DakkaLinqDataContext db = new DakkaLinqDataContext(ConnectionString);

            return db;
        }
    }
}
