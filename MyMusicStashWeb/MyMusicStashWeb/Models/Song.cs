using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Song
    {

        private int MusicID;
        private int accountID;
        private string Music_type;
        private string Music_name;
        private string Artist_name;
        private string Album_name;
        private DateTime Music_date;
        private string Music_Source;
        private string Music_extension;

        public int MusicId
        {
            get { return MusicID; }
            set { MusicID = value; }
        }

        public int AccountId
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public string MusicType
        {
            get { return Music_type; }
            set { Music_type = value; }
        }

        public string MusicName
        {
            get { return Music_name; }
            set { Music_name = value; }
        }

        public string ArtistName
        {
            get { return Artist_name; }
            set { Artist_name = value; }
        }

        public string AlbumName
        {
            get { return Album_name; }
            set { Album_name = value; }
        }

        public DateTime MusicDate
        {
            get { return Music_date; }
            set { Music_date = value; }
        }

        public string MusicSource
        {
            get { return Music_Source; }
            set { Music_Source = value; }
        }

        public string MusicExtension
        {
            get { return Music_extension; }
            set { Music_extension = value; }
        }

        public Song(int MusicID, int accountID, string music_type, string music_name, string artist_name, string album_name, DateTime music_date, string music_Source, string music_extension)
        {
            this.MusicID = MusicID;
            this.accountID = accountID;
            Music_type = music_type;
            Music_name = music_name;
            Artist_name = artist_name;
            Album_name = album_name;
            Music_date = music_date;
            Music_Source = music_Source;
            Music_extension = music_extension;
        }

        public override string ToString()
        {
            return "Music ID: " + MusicID.ToString() + "Music type: " + Music_type + "Music Name: " + Music_name + "Artist name: " + Artist_name + "Album name: " + Album_name + "Music Date: " + Music_date.ToString() + "Music Source: " + Music_Source + "Music Extension: " + Music_extension;
        }
    }
}