using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.Models
{
    public class Person
    {
        private string Firstname;
        private string Lastname;
        private DateTime BirDateTime;
        private int Age;
        private string Gender;

        public string Firstname1
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        public string Lastname1
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        public DateTime BirDateTime1
        {
            get { return BirDateTime; }
            set { BirDateTime = value; }
        }

        public int Age1
        {
            get { return Age; }
            set { Age = value; }
        }

        public string Gender1
        {
            get { return Gender; }
            set { Gender = value; }
        }


        public Person(string firstname, string lastname, DateTime birDateTime, int age, string gender)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.BirDateTime = birDateTime;
            this.Gender = gender;
           this.Age = age;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}