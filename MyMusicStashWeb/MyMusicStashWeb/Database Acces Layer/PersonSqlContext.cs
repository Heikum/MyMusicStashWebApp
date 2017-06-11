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
        //Returned persoonlijke details na ingeven persoon ID
        public Person GetPersonDetails(int id)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Person] WHERE Person_ID = @id;", connectie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Person person = CreatePersonFromReader(reader);
                        return person;
                    }
                }
            }
            return null;
        }

        // Update details van een persoon in de database. 
        public bool UpdateDetails(int id, Person person)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 =
                    new SqlCommand(
                        @"UPDATE [dbo].[Person] SET [Name] = @voornaam, [Lastname] = @achternaam, [Gender] = @geslacht, [Age] = @age, [Birthdate] = @birthdate WHERE Person_ID = @id",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Parameters.AddWithValue("@voornaam", person.Firstname1);
                cmd1.Parameters.AddWithValue("@achternaam", person.Lastname1);
                cmd1.Parameters.AddWithValue("@geslacht", person.Gender1);
                cmd1.Parameters.AddWithValue("@age", person.Age1);
                cmd1.Parameters.AddWithValue("@birthdate", person.BirDateTime1);
                cmd1.ExecuteNonQuery();
                return true;
            }
        }


        // Maakt een persoon aan via de sqldatareader en returned deze
        public Person CreatePersonFromReader(SqlDataReader reader)
        {
            return new Person(
                Convert.ToString(reader["Name"]),
                Convert.ToString(reader["Lastname"]),
                Convert.ToDateTime(reader["Birthdate"]),
                Convert.ToInt32(reader["Age"]),
                Convert.ToString(reader["Gender"]));

        }


    }
}