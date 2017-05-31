using MyMusicStashWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Repository_s
{
    public class SongRepository
    {
        private ISongSqlContext context;

        public SongRepository(ISongSqlContext context)
        {
            this.context = context;
        }
    }
}