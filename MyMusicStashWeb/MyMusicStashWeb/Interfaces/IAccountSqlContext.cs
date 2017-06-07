using System;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface IAccountSqlContext
    {
        bool Login(Account account);
        int GetaccountId(string username);

        bool Register(Account account);

        bool DeleteAccount(int accountId);
        bool InsertPerson(Account acount);
        bool EditAccount(Account account);
        Account GetById(int id);
        bool CheckHash(int ID, string hash);
        bool ActivateAccount(int ID);
        bool GetActivationStatus(int ID); 


    }
}