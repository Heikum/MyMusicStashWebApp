using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Database_Acces_Layer
{
    //Deze klassen bevat de connectie string die door de hele applicatie gebruikt wordt om te connecten met de SQL database. 
    public class Database
    {
        // van fontys
        //private static readonly string connectionString = "Data Source=mssql.fhict.local;Database=dbi353348;User Id=dbi353348;Password=loler123;";
        private static readonly string connectionString = @"Server=WIN-SERVER-R2-6\SQLEXPRESS;Database=dbi353348;User ID = DatabaseHicham; Password=Hicham";
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    connection.Close();
                }
                return connection;
            }
        }
    }
}