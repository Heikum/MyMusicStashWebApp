using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Image: Media
    {
        private string ImageUrl;

        [DisplayName("Image Url")]
        public string ImageUrl1
        {
            get { return ImageUrl; }
            set { ImageUrl = value; }
        }

        public Image(string imageUrl, int mediaId, int accountId, DateTime Media_Date, string Media_Type) : base (mediaId, accountId, Media_Date, Media_Type)
        {
            ImageUrl = imageUrl;
            base.MediaId = mediaId;
            base.AccountId = accountId;
            base.MediaDate = Media_Date;
            base.MediaType = Media_Type; 
        }


    }
}