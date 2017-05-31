using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb
{
    public class PersonRepository
    {
        private IPersonSqlContext context;

        public PersonRepository(IPersonSqlContext context)
        {
            this.context = context;
        }

        public Person GetPersonDetails(string username)
        {
            return this.context.GetPersonDetails(username); 
        }

        public bool UpdateDetails(Account account, Person person)
        {
            return this.context.UpdateDetails(account, person);
        }

    }
}