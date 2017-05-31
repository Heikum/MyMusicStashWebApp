using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb.Database_Acces_Layer
{
    public class AccountSqlContext : IAccountSqlContext
    {
        public int accountID { get; set; }

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM [Account] 
                                        WHERE Username=@uname and 
                                        Password=@pass", connection);
                cmd.Parameters.AddWithValue("@uname", gebruikersnaam);
                cmd.Parameters.AddWithValue("@pass", wachtwoord);
                var result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    //connection.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public int GetaccountId(string username)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT Account_ID FROM Account WHERE Username=@uname;",
                    connectie);
                cmd1.Parameters.AddWithValue("@uname", username);
                accountID = (int)cmd1.ExecuteScalar();
                Console.WriteLine(accountID);
                connectie.Close();
                return accountID;
            }
        }


        public bool Registreer(string username, string password, string firstname, string lastname, string gender,
            int age, DateTime registerDateTime, DateTime birthDate)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"INSERT INTO[dbo].[Account] ([Username], [Password], [Creation_Date]) VALUES (@username, @password, @date)",
                        connectie);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectie;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@date", registerDateTime);
                connectie.Open();
                cmd.ExecuteNonQuery();
                accountID = GetaccountId(username);

                SqlCommand cmd1 =
                    new SqlCommand(
                        @"SET IDENTITY_INSERT Person ON INSERT INTO[dbo].[Person] ([Person_ID], [Name], [Lastname], [Gender], [Age], [Birthdate]) VALUES (@id, @voornaam, @achternaam, @geslacht, @age, @birthdate)",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@voornaam", firstname);
                cmd1.Parameters.AddWithValue("@achternaam", lastname);
                cmd1.Parameters.AddWithValue("@geslacht", gender);
                cmd1.Parameters.AddWithValue("@age", age);
                cmd1.Parameters.AddWithValue("@birthdate", birthDate);
                cmd1.Parameters.Add("@id", SqlDbType.Int);
                cmd1.Parameters["@id"].Value = accountID;
                cmd1.ExecuteNonQuery();
                return true;
            }
        }

        public bool DeleteAccount(int accountId)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                return true;
            }
        }

    }
}