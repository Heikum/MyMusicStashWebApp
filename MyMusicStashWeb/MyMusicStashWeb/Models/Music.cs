using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Music
    {
        private int MusicID { get; set; }
        private int accountID { get; set; }
        private string Music_type { get; set; }
        private string Music_name { get; set; }
        private string Artist_name { get; set; }
        private string Album_name { get; set; }
        private DateTime Music_date { get; set; }
        private string Music_Source { get; set; }
        private string Music_extension { get; set; }

        public Music(int MusicID, int accountID, string music_type, string music_name, string artist_name, string album_name, DateTime music_date, string music_Source, string music_extension)
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