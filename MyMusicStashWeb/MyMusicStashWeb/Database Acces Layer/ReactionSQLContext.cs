using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyMusicStashWeb
{
    class ReactionSQLContext
    {
        public List<Reaction> GetReactions(int postID)
        {
            List<Reaction> collectie = new List<Reaction>();
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Reaction] WHERE PostID= @id;", connectie);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = postID;
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
