using System.Collections.Generic;

namespace MyMusicStashWeb.Interfaces
{
    public interface IPostSqlContext
    {
        List<Post> GetAllPosts();
        bool InsertPost(Post post);
        bool DeletePost(Post post);
        bool EditPost(Post post);
        Post GetPost(int postId);
    }
}