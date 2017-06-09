using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Reaction
    {
        private int reactionID;
        private int accountID;
        private int postID;
        private string post;

        public int ReactionId
        {
            get { return reactionID; }
            set { reactionID = value; }
        }

        public int AccountId
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public int PostId
        {
            get { return postID; }
            set { postID = value; }
        }

        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        public Reaction(int reactionID, int accountID, int postID, string post)
        {
            this.reactionID = reactionID;
            this.accountID = accountID;
            this.postID = postID;
            this.post = post;
        }


        public Reaction(int accountID, int postID, string post)
        {
            this.accountID = accountID;
            this.postID = postID;
            this.post = post;
        }

        public override string ToString()
        {
            return "Account ID: " + Environment.NewLine + accountID + " Post: " + post;
        }
    }
}