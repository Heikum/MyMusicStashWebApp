using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Video: Media
    {
        private string VideoUrl;

        [DisplayName("Video Url")]
        public string VideoUrl1
        {
            get { return VideoUrl; }
            set { VideoUrl = value; }
        }

        public Video(string videoUrl, int mediaId, int accountId, DateTime Media_Date, string Media_Type) : base(mediaId, accountId, Media_Date, Media_Type)
        {
            VideoUrl = videoUrl;
            base.MediaId = mediaId;
            base.AccountId = accountId;
            base.MediaDate = Media_Date;
            base.MediaType = Media_Type;
        }

        

    }
}