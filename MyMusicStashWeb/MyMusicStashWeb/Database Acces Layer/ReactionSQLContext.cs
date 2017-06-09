using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.database_Acces_layer
{
    class ReactionSqlContext : IReactionSqlContext
    {
        public List<Reaction> GetSpecificReactions(int postId)
        {
            List<Reaction> collectie = new List<Reaction>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Reaction] WHERE PostID= @id;", connectie);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = postId;
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

        public Reaction GetById(int reactionId)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Post where Post_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", reactionId);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reaction reaction = CreateCollectionFromReader(reader);
                        return reaction;
                    }
                }
            }
            return null;
        }


        public List<Reaction> GetAllReactions()
        {
            List<Reaction> collectie = new List<Reaction>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reaction;", connectie);
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

        public bool InsertReaction(Reaction reaction)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "Insert into Reaction (Account_ID, PostID, Post) values (@AccountID, @PostID, @post);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", reaction.AccountId);
                    command.Parameters.AddWithValue("@PostID", reaction.PostId);
                    command.Parameters.AddWithValue("@Post", reaction.Post);

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

        public bool DeleteReaction(Reaction reaction)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM Reaction where Reaction_ID = @ID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", reaction.PostId);
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

        public bool EditReaction(Reaction reaction)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "update Reaction set Post = @post where Reaction_ID = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", reaction.ReactionId);
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

        private Reaction CreateCollectionFromReader(SqlDataReader reader)
        {
            return new Reaction(
                Convert.ToInt32(reader["Reaction_ID"]),
                Convert.ToInt32(reader["Account_ID"]),
                Convert.ToInt32(reader["PostID"]),
                Convert.ToString(reader["Post"]));
        }

    }
}
