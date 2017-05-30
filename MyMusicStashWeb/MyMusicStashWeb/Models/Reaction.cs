using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Reaction
    {
        private int reactionID { get; set; }
        private int accountID { get; set; }
        private int postID { get; set; }
        private string post { get; set; }

        public Reaction(int reactionID, int accountID, int postID, string post)
        {
            this.reactionID = reactionID;
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