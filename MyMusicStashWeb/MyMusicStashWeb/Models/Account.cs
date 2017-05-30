using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Account
    {
        private string Username { get; set; }
        private string Password { get ; set; }

        public Account(string uname, string pword)
        {
            this.Username = uname;
            this.Password = pword;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}