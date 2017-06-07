using System.Collections.Generic;
using System.Data.SqlClient;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface ISongSqlContext
    {
        bool AddSong(Song song);
        bool AddNewSongProcedure(Song song);
        bool EditSong(int musicId, Song song);
        List<Song> GetAllSongsFromUser(int accountId);
        List<Song> GetAllSongs();
        bool DeleteSong(int musicId);
        Song GetById(int musicId); 
    }
}