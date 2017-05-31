using MyMusicStashWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Repository_s
{
    public class SongRepository
    {
        private ISongSqlContext context;

        public SongRepository(ISongSqlContext context)
        {
            this.context = context;
        }

        public bool AddSong(Song song, int accountId)
        {
            return this.context.AddSong(song, accountId);
        }

        public bool AddNewSongProcedure(int accountId, Song song)
        {
            return this.context.AddNewSongProcedure(accountId, song); 
        }

        public bool EditSong(int musicId, Song song)
        {
            return this.context.EditSong(musicId, song); 
        }

        public List<Song> GetAllSongsFromUser(int accountId)
        {
            return this.context.GetAllSongsFromUser(accountId); 
        }

        public List<Song> GetAllSongs()
        {
            return this.context.GetAllSongs();
        }

        public bool DeleteSong(int musicId)
        {
            return this.context.DeleteSong(musicId); 
        }

    }
}