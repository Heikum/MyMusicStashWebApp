using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 

namespace MyMusicStashWeb
{
    class ProfileSQLContext
    {
        public List<Music> GetMusic(int accountID)
        {
            List<Music> collectie = new List<Music>(); 
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Music_Collection] WHERE Account_ID = @id;", connectie);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = accountID;
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

        private Music CreateCollectionFromReader(SqlDataReader reader)
        {
            return new Music(
                Convert.ToInt32(reader["Music_ID"]),
                Convert.ToInt32(reader["Account_ID"]),
                Convert.ToString(reader["Music_type"]),
                Convert.ToString(reader["Music_name"]),
                Convert.ToString(reader["Artist_name"]),
                Convert.ToString(reader["Album_name"]),
                Convert.ToDateTime(reader["Music_date"]),
                Convert.ToString(reader["Music_source"]),
                Convert.ToString(reader["Music_extension"]));
        }

    }
}
