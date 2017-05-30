using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb
{
    public class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birDateTime { get; set; }
        public int age { get; set; }
        public string gender { get; set; }


        public Person(string firstname, string lastname, DateTime birDateTime, int personage, string gender)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.birDateTime = birDateTime;
            this.gender = gender;
            age = personage;
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