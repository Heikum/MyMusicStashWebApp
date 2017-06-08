using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public abstract class Media
    {
        private DateTime Media_Date;
        private string Media_Type;
        private int MediaID;
        private int AccountID;

        [DisplayName("Media ID")]
        public int MediaId
        {
            get { return MediaID; }
            set { MediaID = value; }
        }

        [DisplayName("Account ID")]
        public int AccountId
        {
            get { return AccountID; }
            set { AccountID = value; }
        }

        protected Media(int mediaId, int accountId, DateTime media_Date, string Media_Type)
        {
            MediaID = mediaId;
            AccountID = accountId;
            Media_Date = media_Date;
            this.Media_Type = Media_Type;
        }


        public DateTime MediaDate
        {
            get { return Media_Date; }
            set { Media_Date = value; }
        }

        public string MediaType
        {
            get { return Media_Type; }
            set { Media_Type = value; }
        }


    }
}