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
                        foundperson.Firstname1 = reader["Name"].ToString();
                        foundperson.Lastname1 = reader["Lastname"].ToString();
                        foundperson.Age1 = Convert.ToInt32(reader["Age"]);
                        foundperson.BirDateTime1 = Convert.ToDateTime(reader["Birthdate"]);
                        foundperson.Gender1 = reader["Gender"].ToString();

                    }
                }
            }
            return foundperson;
        }


        public bool UpdateDetails(Account account, Person person)
        {
            accountID = GetaccountId(account.Username1);
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE [dbo].[Account] SET [Username] = @username, [Password] = @password WHERE Account_ID=@id",
                        connectie);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectie;
                cmd.Parameters.AddWithValue("@username", account.Username1);
                cmd.Parameters.AddWithValue("@password", account.Password1);

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = accountID;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 =
                    new SqlCommand(
                        @"UPDATE [dbo].[Person] SET [Name] = @voornaam, [Lastname] = @achternaam, [Gender] = @geslacht, [Age] = @age, [Birthdate] = @birthdate WHERE Person_ID = @id2",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@voornaam", person.Firstname1);
                cmd1.Parameters.AddWithValue("@achternaam", person.Lastname1);
                cmd1.Parameters.AddWithValue("@geslacht", person.Gender1);
                cmd1.Parameters.AddWithValue("@age", person.Age1);
                cmd1.Parameters.AddWithValue("@birthdate", person.BirDateTime1);
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