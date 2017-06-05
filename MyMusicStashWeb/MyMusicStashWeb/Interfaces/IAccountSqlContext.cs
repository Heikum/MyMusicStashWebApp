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
    }
}