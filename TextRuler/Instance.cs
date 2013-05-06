using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace DAL
{
    public static class ConnectionManager
    {
        public static string ConnectionStringSQLite
        {
            get
            {
                 
                string database = ConfigurationManager.AppSettings["database"] != null ? ConfigurationManager.AppSettings["database"] :   AppDomain.CurrentDomain.BaseDirectory + "data.s3db";
                string connectionString = @"Data Source=" + Path.GetFullPath(database);
                return connectionString;
            }
        }
    }
}
