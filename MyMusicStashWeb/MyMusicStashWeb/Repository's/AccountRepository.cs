using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;

namespace MyMusicStashWeb
{
    public class AccountRepository
    {
        private IAccountSqlContext context;

        public AccountRepository(IAccountSqlContext context)
        {
            this.context = context;
        }
    }
}