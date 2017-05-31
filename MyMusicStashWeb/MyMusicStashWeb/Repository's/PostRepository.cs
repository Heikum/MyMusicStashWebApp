using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb
{
    public class PostRepository
    {
        private IPostSqlContext context;

        public PostRepository(IPostSqlContext context)
        {
            this.context = context;
        }

    }
}