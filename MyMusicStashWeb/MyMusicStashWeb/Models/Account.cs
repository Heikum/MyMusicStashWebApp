using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Account
    {

        private string Username;
        private string Password;
        private int accountId;
        private string Email;

        [DisplayName("Email")]
        public string Email1
        {
            get { return Email; }
            set { Email = value; }
        }

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        private Person person;


        [DisplayName("Account ID")]
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        [DisplayName("Username")]
        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }
        [DisplayName("Password")]
        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public Account(string uname, string pword)
        {
            this.Username = uname;
            this.Password = pword;
        }

        public Account(string uname, string pword, string email, Person person)
        {
            this.Username = uname;
            this.Password = pword;
            this.person = person;
            this.Email = email;
        }

        public Account(string uname, string pword, int id, string email)
        {
            this.Username = uname;
            this.Password = pword;
            this.accountId = id;
            this.Email = email;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}