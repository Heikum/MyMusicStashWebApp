using System;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface IPersonSqlContext
    {
        Person GetPersonDetails(string username);

        bool UpdateDetails(Account account, Person person);

        int GetaccountId(string username);
    }
}