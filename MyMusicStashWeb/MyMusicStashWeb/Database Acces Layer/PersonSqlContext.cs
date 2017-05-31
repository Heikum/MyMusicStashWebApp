using MyMusicStashWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb.Database_Acces_Layer
{
    public class PersonSqlContext : IPersonSqlContext
    {
        private int accountID;
        public Person GetPersonDetails(string username)
        {
            Person foundperson = new Person("kk", "kk", new DateTime(3, 3, 3), 5, "male");
            accountID = GetaccountId(username);
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Person] WHERE Person_ID = @id;", connectie);
                //cmd.Parameters.AddWithValue("@id", accountID);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                Console.WriteLine(accountID);
                cmd.Parameters["@id"].Value = accountID;
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foundperson.Firstname = reader["Name"].ToString();
                        Console.WriteLine(foundperson.Firstname);
                        foundperson.Lastname = reader["Lastname"].ToString();
                        foundperson.Age = Convert.ToInt32(reader["Age"]);
                        foundperson.BirDateTime = Convert.ToDateTime(reader["Birthdate"]);
                        foundperson.Gender = reader["Gender"].ToString();

                    }
                }
            }
            return foundperson;
        }


        public bool UpdateDetails(string username, string password, string firstname, string lastname, string gender,
           int age, DateTime birthDate)
        {
            accountID = GetaccountId(username);
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE [dbo].[Account] SET [Username] = @username, [Password] = @password WHERE Account_ID=@id",
                        connectie);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectie;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = accountID;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 =
                    new SqlCommand(
                        @"UPDATE [dbo].[Person] SET [Name] = @voornaam, [Lastname] = @achternaam, [Gender] = @geslacht, [Age] = @age, [Birthdate] = @birthdate WHERE Person_ID = @id2",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@voornaam", firstname);
                cmd1.Parameters.AddWithValue("@achternaam", lastname);
                cmd1.Parameters.AddWithValue("@geslacht", gender);
                cmd1.Parameters.AddWithValue("@age", age);
                cmd1.Parameters.AddWithValue("@birthdate", birthDate);
                cmd1.Parameters.Add("@id2", SqlDbType.Int);
                cmd1.Parameters["@id2"].Value = accountID;
                cmd1.ExecuteNonQuery();
                return true;
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


    }
}