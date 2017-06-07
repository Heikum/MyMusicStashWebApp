﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Database_Acces_Layer
{
    public class AccountSqlContext : IAccountSqlContext
    {
        public int accountID { get; set; }

        public bool Login(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM [Account] 
                                        WHERE Username=@uname and 
                                        Password=@pass", connection);
                cmd.Parameters.AddWithValue("@uname", account.Username1);
                cmd.Parameters.AddWithValue("@pass", account.Password1);
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


        public bool Register(Account account)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"INSERT INTO[dbo].[Account] ([Username], [Password], [Creation_Date]) VALUES (@username, @password, @date)",
                        connectie);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectie;
                cmd.Parameters.AddWithValue("@username", account.Username1);
                cmd.Parameters.AddWithValue("@password", account.Password1);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                InsertPerson(account);
                return true;
            }
        }

        public bool InsertPerson(Account account)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                accountID = GetaccountId(account.Username1);
                SqlCommand cmd1 =
                    new SqlCommand(
                        @"SET IDENTITY_INSERT Person ON INSERT INTO[dbo].[Person] ([Person_ID], [Name], [Lastname], [Gender], [Age], [Birthdate]) VALUES (@id, @voornaam, @achternaam, @geslacht, @age, @birthdate)",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@voornaam", account.Person.Firstname1);
                cmd1.Parameters.AddWithValue("@achternaam", account.Person.Lastname1);
                cmd1.Parameters.AddWithValue("@geslacht", account.Person.Gender1);
                cmd1.Parameters.AddWithValue("@age", account.Person.Age1);
                cmd1.Parameters.AddWithValue("@birthdate", account.Person.BirDateTime1);
                cmd1.Parameters.Add("@id", SqlDbType.Int);
                cmd1.Parameters["@id"].Value = accountID;
                cmd1.ExecuteNonQuery();
                return true;
            }
        }

        public Account GetById(int id)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Account where Account_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = CreateAccountFromReader(reader);
                        return account;
                    }
                }
            }
            return null;
        }

        public bool EditAccount(Account account)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd1 =
                    new SqlCommand(
                        @"update Account set Password = @Password, Email = @Email where  Account_ID = @id",
                        connectie);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = connectie;
                cmd1.Parameters.AddWithValue("@id", account.AccountId);
                cmd1.Parameters.AddWithValue("@Password", account.Password1);
                cmd1.Parameters.AddWithValue("@Email", account.Email1);
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

        public Account CreateAccountFromReader(SqlDataReader reader)
        {
            return new Account(
                Convert.ToString(reader["Username"]),
                Convert.ToString(reader["Password"]),
                Convert.ToInt32(reader["Account_ID"]),
                Convert.ToString(reader["Email"]));
        }


    }
}