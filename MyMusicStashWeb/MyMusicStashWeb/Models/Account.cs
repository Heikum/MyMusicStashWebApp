using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Account
    {
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }

        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        private string Username;
        private string Password;
        private int accountId; 

        public Account(string uname, string pword)
        {
            this.Username = uname;
            this.Password = pword;
        }

        public Account(string uname, string pword, int id)
        {
            this.Username = uname;
            this.Password = pword;
            this.accountId = id; 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}