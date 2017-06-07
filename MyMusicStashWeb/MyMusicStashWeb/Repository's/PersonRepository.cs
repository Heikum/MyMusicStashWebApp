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

        public Person GetPersonDetails(int id)
        {
            return context.GetPersonDetails(id); 
        }

        public bool UpdateDetails(int id, Person person)
        {
            return context.UpdateDetails(id, person);
        }

    }
}