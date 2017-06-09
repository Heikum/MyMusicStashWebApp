using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Database_Acces_Layer
{

    public class MediaSqlContext : IMediaSqlContext
    {

        public bool InsertMedia(Image image)
        {
            using (SqlConnection connection = Database.Connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(@"Insert into Media (Account_ID, Media_Url, Media_date, Media_type) values (@AccountID, @MediaUrl, @MediaDate, @Mediatype);", connection);
                    cmd.Parameters.AddWithValue("@AccountID", image.AccountId);
                    cmd.Parameters.AddWithValue("@MediaUrl", image.ImageUrl1);
                    cmd.Parameters.AddWithValue("@MediaDate", image.MediaDate);
                    cmd.Parameters.AddWithValue("@Mediatype", image.MediaType);
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        public int GetAccountMediaID(int id)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT Account_ID FROM [Music_collection] WHERE Music_ID = @id;", connectie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int accountid = Convert.ToInt32(reader["Account_ID"]);
                        return accountid;
                    }
                }
            }
            return 1;
        }

        public bool InsertMedia(Video video)
        {
            using (SqlConnection connection = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(@"Insert into Media (Account_ID, Media_Url, Media_date, Media_type) values (@AccountID, @MediaUrl, @MediaDate, @Mediatype);", connection);
                cmd.Parameters.AddWithValue("@AccountID", video.AccountId);
                cmd.Parameters.AddWithValue("@MediaUrl", video.VideoUrl1);
                cmd.Parameters.AddWithValue("@MediaDate", video.MediaDate);
                cmd.Parameters.AddWithValue("@Mediatype", video.MediaType);
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Media Getmedia(int mediaId)
        {
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Media where Media_ID = @id; ";
                SqlCommand cmd = new SqlCommand(query, connectie);
                cmd.Parameters.AddWithValue("@id", mediaId);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Media media = (CreateCollectionFromReader(reader));
                        return media; 
                    }
                }
            }
            return null; 
        }

        private Media CreateCollectionFromReader(SqlDataReader reader)
        {
            if (Convert.ToString(reader["Media_Type"]) == "Video")
            {
                return new Video(
               Convert.ToString(reader["Media_Url"]),
               Convert.ToInt32(reader["Account_ID"]),
               Convert.ToInt32(reader["Media_ID"]),
               Convert.ToDateTime(reader["Media_date"]), 
               Convert.ToString(reader["Media_Type"]));
            }
            if (Convert.ToString(reader["Media_Type"]) == "Image")
            {
                return new Image(Convert.ToString(reader["Media_Url"]),
               Convert.ToInt32(reader["Account_ID"]),
               Convert.ToInt32(reader["Media_ID"]),
               Convert.ToDateTime(reader["Media_date"]),
               Convert.ToString(reader["Media_Type"]));
            }
            else
            {
                return null;
            }
        }

        public bool DeleteMedia(int mediaId)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "delete from Media where Media_ID = @id;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", mediaId);
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

        public List<Media> GetAllMedia()
        {
            List<Media> collectie = new List<Media>();
            using (SqlConnection connectie = Database.Connection)
            {
                string query = "select * from Media;";
                SqlCommand cmd = new SqlCommand(query, connectie);
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


    }
    }