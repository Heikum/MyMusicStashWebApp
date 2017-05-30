using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyMusicStashWeb
{
    class SongSQLContext
    {
        public bool AddSong(int accountID, string musictype, string musicname, string artistname, string albumname, DateTime musicdate, string musicsource, string musicextension)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Music_collection (Account_ID, Music_type, Music_name, Artist_name, Album_name, Music_date, Music_source, Music_extension)" +
                    "VALUES (@Account_ID, @Music_type, @Music_name, @Artist_name, @Album_name, @Music_date, @Music_source, @Music_extension)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account_ID", accountID);
                    command.Parameters.AddWithValue("@Music_type", musictype);
                    command.Parameters.AddWithValue("@Music_name", musicname);
                    command.Parameters.AddWithValue("@Artist_name", artistname);
                    command.Parameters.AddWithValue("@Album_name", albumname);
                    command.Parameters.AddWithValue("@Music_date", musicdate);
                    command.Parameters.AddWithValue("@Music_source", musicsource);
                    command.Parameters.AddWithValue("@Music_extension", musicextension);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public bool AddNewSong(int accountID, string musictype, string musicname, string artistname, string albumname, DateTime musicdate, string musicsource, string musicextension)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXECUTE InsertNewSong @Account_ID = @Account_ID1, @Music_type = @Music_type1, @Music_name = @Music_name1, @Artist_name = @Artist_name1, @Album_name = @Album_name1, @Music_date = @Music_date1, @Music_source = @Music_source1, @Music_extension = @Music_extension1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account_ID1", accountID);
                    command.Parameters.AddWithValue("@Music_type1", musictype);
                    command.Parameters.AddWithValue("@Music_name1", musicname);
                    command.Parameters.AddWithValue("@Artist_name1", artistname);
                    command.Parameters.AddWithValue("@Album_name1", albumname);
                    command.Parameters.AddWithValue("@Music_date1", musicdate);
                    command.Parameters.AddWithValue("@Music_source1", musicsource);
                    command.Parameters.AddWithValue("@Music_extension1", musicextension);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }


    }
}
