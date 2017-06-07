using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb
{
    public class AccountRepository
    {
        private IAccountSqlContext context;

        public AccountRepository(IAccountSqlContext context)
        {
            this.context = context;
        }

        public bool EditAccount(Account account)
        {
            return context.EditAccount(account); 
        }

        public bool Login(Account account)
        {
            return context.Login(account); 
        }

        public int GetaccountId(string username)
        {
            return context.GetaccountId(username); 
        }

        public Account GetById(int id)
        {
            return context.GetById(id);
        }

        public bool Register(Account account)
        {
            return context.Register(account);
        }

        public bool InserPerson(Account account)
        {
            return context.InsertPerson(account);
        }

        public bool DeleteAccount(int accountId)
        {
            return context.DeleteAccount(accountId); 
        }

    }
}