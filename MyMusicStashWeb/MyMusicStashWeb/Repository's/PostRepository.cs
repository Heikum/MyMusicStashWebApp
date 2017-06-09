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

        public int GetAccountPostID(int id)
        {
            return context.GetAccountPostID(id); 
        }

        public bool DeletePost(int id)
        {
            return context.DeletePost(id);
        }

        public Post GetPost(int id)
        {
            return context.GetPost(id); 
        }

        public bool EditPost(Post post)
        {
            return context.EditPost(post);
        }



    }
}