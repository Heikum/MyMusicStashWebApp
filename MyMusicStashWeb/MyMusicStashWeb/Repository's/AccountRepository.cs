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

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            return context.Inloggen(gebruikersnaam, wachtwoord); 
        }

        public int GetaccountId(string username)
        {
            return context.GetaccountId(username); 
        }

        public bool Registreer(string username, string password, string firstname, string lastname, string gender,
            int age, DateTime registerDateTime, DateTime birthDate)
        {
            return context.Registreer(username, password, firstname, lastname, gender, age, registerDateTime,
                birthDate);
        }

        public bool DeleteAccount(int accountId)
        {
            return context.DeleteAccount(accountId); 
        }

    }
}