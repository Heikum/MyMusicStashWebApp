using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Post
    {
        private int postID { get; set; }
        private int accountID { get; set; }
        private string posttext { get; set; }
        private string Username { get; set; }

        public int PostID
        {
            get
            {
                return postID;
            }

            set
            {
                postID = value;
            }
        }

        public Post(int postID, int accountID, string username, string posttext)
        {
            this.postID = postID;
            this.accountID = accountID;
            this.Username = username;
            this.posttext = posttext;
        }

        public override string ToString()
        {
            return "Username: " + Username + Environment.NewLine + " Post: " + posttext;
        }
    }
}