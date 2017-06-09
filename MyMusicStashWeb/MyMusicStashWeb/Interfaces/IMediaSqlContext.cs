using System.Collections.Generic;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Database_Acces_Layer
{
    public interface IMediaSqlContext
    {
        bool InsertMedia(Image image);
        bool InsertMedia(Video video);
        Media Getmedia(int mediaId);
        bool DeleteMedia(int mediaId);
        List<Media> GetAllMedia();
        int GetAccountMediaID(int id); 
    }
}