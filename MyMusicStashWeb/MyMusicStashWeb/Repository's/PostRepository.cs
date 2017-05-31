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

        public List<Post> GetAllPosts()
        {
            return context.GetAllPosts(); 
        }

        public bool InsertPost(Post post)
        {
            return context.InsertPost(post);
        }

        public bool DeletePost(Post post)
        {
            return context.DeletePost(post);
        }

        public bool EditPost(Post post)
        {
            return context.EditPost(post);
        }



    }
}