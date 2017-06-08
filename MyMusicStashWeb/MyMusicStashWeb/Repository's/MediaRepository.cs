using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb
{
    public class MediaRepository
    {
        private IMediaSqlContext context;
        public MediaRepository(IMediaSqlContext context)
        {
            this.context = context;
        }

        public bool InsertMedia(Image image)
        {
            return context.InsertMedia(image); 
        }
        public bool InsertMedia(Video video)
        {
            return context.InsertMedia(video);
        }

        public Media Getmedia(int mediaId)
        {
            return context.Getmedia(mediaId);
        }

        public bool DeleteMedia(int mediaId)
        {
            return context.DeleteMedia(mediaId); 
        }

        public List<Media> GetAllMedia()
        {
            return context.GetAllMedia(); 
        }

    }
}