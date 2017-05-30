using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Database
    {
        private static readonly string connectionString = "Data Source=mssql.fhict.local;Database=dbi353348;User Id=dbi353348;Password=loler123;";
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}