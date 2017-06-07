using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Post
    {

        private int postID;
        private int accountID;
        private string posttext;
        private string Username;

        public int PostId
        {
            get { return postID; }
            set { postID = value; }
        }

        public int AccountId
        {
            get { return accountID; }
            set { accountID = value; }
        }

        [DisplayName("Post:")]
        public string Posttext
        {
            get { return posttext; }
            set { posttext = value; }
        }
        [DisplayName("Username:")]
        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }

        public Post(int postID, int accountID, string username, string posttext)
        {
            this.postID = postID;
            this.accountID = accountID;
            this.Username = username;
            this.posttext = posttext;
        }

        public Post(int postID)
        {
            this.postID = postID;

        }
        public Post(int accountID, string posttext)
        {
            this.accountID = accountID;
            this.posttext = posttext;
        }

        public override string ToString()
        {
            return "Username: " + Username + Environment.NewLine + " Post: " + posttext;
        }
    }
}