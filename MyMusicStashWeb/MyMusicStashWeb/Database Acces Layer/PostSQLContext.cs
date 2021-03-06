﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyMusicStashWeb;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.database_Acces_layer
{
    class PostsqlContext : IPostSqlContext
    {
        // Geeft alle posts uit de database in een list terug, inner join om username erbij te krijgen
        public List<Post> GetAllPosts()
        {
            List<Post> collectie = new List<Post>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("select p.Post_ID, p.Account_ID, Account.Username as Username, p.Post from post as p INNER JOIN Account ON Account.Account_ID = p.Account_ID;", connectie);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collectie.Add(CreateCollectionFromReader(reader));
                    }
                }
            }
            return collectie;
        }
        //Returned alle posts van een specifieke gebruiker 
        public List<Post> GetSpecificPosts(int accountId)
        {
            List<Post> collectie = new List<Post>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Post where Account_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collectie.Add(CreateCollectionFromReader(reader));
                    }
                }
            }
            return collectie;
        }

        public bool InsertPost(Post post)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "insert into Post (Account_ID, Post) values (@AccountID, @Post);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", post.AccountId);
                    command.Parameters.AddWithValue("@Post", post.Posttext);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {

                    }
                    return false;
                }
            }
        }

        public bool EditPost(Post post)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "update Post set Post.Post = @post where Post_ID = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@post", post.Posttext);
                    command.Parameters.AddWithValue("@id", post.PostId);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {

                    }
                    return false;
                }
            }
        }

        public Post GetPost(int postId)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Post p INNER JOIN Account a on a.Account_ID = p.Account_ID where p.Post_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", postId);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Post post = (CreateCollectionFromReader(reader));
                        return post;
                    }
                }
            }
            return null;
        }

        public bool DeletePost(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {

                using (SqlCommand command = new SqlCommand("EXECUTE DeletePost @Post_ID = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    return false;
                }
            }
        }

        public int GetAccountPostID(int id)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT Account_ID FROM [Post] WHERE Post_ID = @id;", connectie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int postid = Convert.ToInt32(reader["Account_ID"]);
                        return postid;
                    }
                }
            }
            return 1;
        }


        private Post CreateCollectionFromReader(SqlDataReader reader)
        {
            return new Post(
                Convert.ToInt32(reader["Post_ID"]),
                Convert.ToInt32(reader["Account_ID"]),
                Convert.ToString(reader["Username"]),
            Convert.ToString(reader["Post"]));
        }

    }
}
