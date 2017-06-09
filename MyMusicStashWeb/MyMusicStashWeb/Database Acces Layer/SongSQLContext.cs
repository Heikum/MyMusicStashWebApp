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
    class SongSQLContext : ISongSqlContext
    {
        public bool AddSong(Song song)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO Music_collection (Account_ID, Music_type, Music_name, Artist_name, Album_name, Music_date, Music_source, Music_extension)" +
                    "VALUES (@Account_ID, @Music_type, @Music_name, @Artist_name, @Album_name, @Music_date, @Music_source, @Music_extension)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account_ID", song.AccountId);
                    command.Parameters.AddWithValue("@Music_type", song.MusicType);
                    command.Parameters.AddWithValue("@Music_name", song.MusicName);
                    command.Parameters.AddWithValue("@Artist_name", song.ArtistName);
                    command.Parameters.AddWithValue("@Album_name", song.AlbumName);
                    command.Parameters.AddWithValue("@Music_date", song.MusicDate);
                    command.Parameters.AddWithValue("@Music_source", song.MusicSource);
                    command.Parameters.AddWithValue("@Music_extension", song.MusicExtension);

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
        //strored procedure
        public bool AddNewSongProcedure(Song song)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "EXECUTE InsertNewSong @Account_ID = @Account_ID1, @Music_type = @Music_type1, @Music_name = @Music_name1, @Artist_name = @Artist_name1, @Album_name = @Album_name1, @Music_date = @Music_date1, @Music_source = @Music_source1, @Music_extension = @Music_extension1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Account_ID1", song.AccountId);
                    command.Parameters.AddWithValue("@Music_type1", song.MusicType);
                    command.Parameters.AddWithValue("@Music_name1", song.MusicName);
                    command.Parameters.AddWithValue("@Artist_name1", song.ArtistName);
                    command.Parameters.AddWithValue("@Album_name1", song.AlbumName);
                    command.Parameters.AddWithValue("@Music_date1", song.MusicDate);
                    command.Parameters.AddWithValue("@Music_source1", song.MusicSource);
                    command.Parameters.AddWithValue("@Music_extension1", song.MusicExtension);

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

        public bool EditSong(int musicId, Song song)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "update Music_collection set Music_type = @musictype, Music_name = @musicname, Artist_name = @artistname, Album_name = @albumname, Music_date = @musicdate, Music_source = @musicsource, Music_extension = @musicextension where Music_ID = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", musicId);
                    command.Parameters.AddWithValue("@musictype", song.MusicType);
                    command.Parameters.AddWithValue("@Musicname", song.MusicName);
                    command.Parameters.AddWithValue("@Artistname", song.ArtistName);
                    command.Parameters.AddWithValue("@Albumname", song.AlbumName);
                    command.Parameters.AddWithValue("@Musicdate", song.MusicDate);
                    command.Parameters.AddWithValue("@Musicsource", song.MusicSource);
                    command.Parameters.AddWithValue("@Musicextension", song.MusicExtension);

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

        public List<Song> GetAllSongsFromUser(int accountId)
        {
            List<Song> collectie = new List<Song>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Music_collection where Account_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collectie.Add(CreateSongFromReader(reader));
                    }
                }
            }
            return collectie;
        }

        public Song GetById(int musicId)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Music_collection where Music_ID = @id;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", musicId);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Song song = CreateSongFromReader(reader);
                        return song; 
                    }
                }
            }
            return null;
        }

        public Song GiveRandomSong(string type)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "EXEC RandomSong @Musictype = @type;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Song song = CreateSongFromReader(reader);
                        return song;
                    }
                }
            }
            return null;
        }



        public List<Song> GetAllSongs()
        {
            List<Song> collectie = new List<Song>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Music_collection;";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collectie.Add(CreateSongFromReader(reader));
                    }
                }
            }
            return collectie;
        }
        //Maakt een song class aan en returned deze
        public Song CreateSongFromReader(SqlDataReader reader)
        {
            return new Song(
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


        public bool DeleteSong(int musicId)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "delete from Music_collection where Music_collection.Music_ID = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", musicId);

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


    }
}
