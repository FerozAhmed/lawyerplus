using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DAL
{
    public static class ConnectionManager
    {
        public static string ConnectionStringSQLite
        {
            get
            {
                string database = AppDomain.CurrentDomain.BaseDirectory + "data.s3db";
                string connectionString = @"Data Source=" + Path.GetFullPath(database);
                return connectionString;
            }
        }
    }
}
