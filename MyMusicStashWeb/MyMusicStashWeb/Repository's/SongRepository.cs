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

        public Song GetById(int id)
        {
            return context.GetById(id); 
        }
        public bool AddSong(Song song)
        {
            return context.AddSong(song);
        }

        public Song GiveRandomSong(string type)
        {
            return context.GiveRandomSong(type); 
        }
        public bool AddNewSongProcedure(Song song)
        {
            return context.AddNewSongProcedure(song); 
        }

        public bool EditSong(int musicId, Song song)
        {
            return context.EditSong(musicId, song); 
        }

        public List<Song> GetAllSongsFromUser(int accountId)
        {
            return context.GetAllSongsFromUser(accountId); 
        }

        public List<Song> GetAllSongs()
        {
            return context.GetAllSongs();
        }

        public bool DeleteSong(int musicId)
        {
            return context.DeleteSong(musicId); 
        }

    }
}