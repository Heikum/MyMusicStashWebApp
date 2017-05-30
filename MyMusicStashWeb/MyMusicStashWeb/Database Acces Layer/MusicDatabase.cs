using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MyMusicStashWeb
{
    class MusicDatabase
    {
        private readonly SqlConnection connection =
            new SqlConnection(@"Server=mssql.fhict.local;Database=dbi353348;User Id=dbi353348;Password=loler123;");

        public int accountID { get; set; }
        private Person person { get; set; }

        //Methodes
        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM [Account] 
                                        WHERE Username=@uname and 
                                        Password=@pass", connection);
                cmd.Parameters.AddWithValue("@uname", gebruikersnaam);
                cmd.Parameters.AddWithValue("@pass", wachtwoord);
                var result = (int) cmd.ExecuteScalar();
                if (result > 0)
                {
                    SqlCommand cmd1 = new SqlCommand(@"SELECT Account_ID FROM Account WHERE Username=@uname;",
                        connection);
                    cmd1.Parameters.AddWithValue("@uname", gebruikersnaam);
                    accountID = (int) cmd1.ExecuteScalar();
                    Console.WriteLine(accountID);
                    //connection.Close();
                    return true;
                }
                else
                {
                    return false;
                    ;
                }
            }
            
        }
        public int GetaccountID(string username)
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
                accountID = GetaccountID(username);

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

        public Person Ophalengegevens(string username)
        {
            Person foundperson = new Person("kk", "kk", new DateTime(3, 3, 3), 5, "male");
            accountID = GetaccountID(username);
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
                        foundperson.firstname = reader["Name"].ToString();
                        Console.WriteLine(foundperson.firstname);
                        foundperson.lastname = reader["Lastname"].ToString();
                        foundperson.age = Convert.ToInt32(reader["Age"]);
                        foundperson.birDateTime = Convert.ToDateTime(reader["Birthdate"]);
                        foundperson.gender = reader["Gender"].ToString();
   
                    }
                }
            }
            return foundperson;
        }


        public bool update(string username, string password, string firstname, string lastname, string gender,
           int age, DateTime birthDate)
        {
            accountID = GetaccountID(username);
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
        public bool deleteAccount(string username)
        {
            accountID = GetaccountID(username);
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd3 =
                    new SqlCommand(
                        @"DELETE FROM [dbo].[Media] WHERE Account_ID=@id4",
                        connectie);

                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = connectie;
                cmd3.Parameters.Add("@id4", SqlDbType.Int);
                cmd3.Parameters["@id4"].Value = accountID;
                cmd3.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand(@"DELETE FROM [dbo].[Person] WHERE Person_ID=@id2",connectie);

                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.Add("@id2", SqlDbType.Int);
                cmd1.Parameters["@id2"].Value = accountID;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand(@"DELETE FROM [dbo].[Music_collection] WHERE Account_ID=@id5",connectie);

                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = connectie;
                cmd5.Parameters.Add("@id5", SqlDbType.Int);
                cmd5.Parameters["@id5"].Value = accountID;
                cmd5.ExecuteNonQuery();

                SqlCommand cmd =
                    new SqlCommand(
                        @"DELETE FROM [dbo].[Account] WHERE Account_ID=@id",
                        connectie);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectie;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = accountID;
                cmd.ExecuteNonQuery();
                return true;
            }
        }

    }
}
