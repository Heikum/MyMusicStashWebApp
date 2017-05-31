using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb
{
    public class PersonRepository
    {
        private IPersonSqlContext context;

        public PersonRepository(IPersonSqlContext context)
        {
            this.context = context;
        }
    }
}