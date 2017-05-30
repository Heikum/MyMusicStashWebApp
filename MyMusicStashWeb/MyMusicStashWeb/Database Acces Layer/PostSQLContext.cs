using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyMusicStashWeb
{
    class PostSQLContext
    {
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

        public bool insertPost(int AccountID, string Posttekst)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "insert into Post (Account_ID, Post) values (@AccountID, @Post); ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    command.Parameters.AddWithValue("@Post", Posttekst);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
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
