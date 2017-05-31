using System;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface IPersonSqlContext
    {
        Person GetPersonDetails(string username);

        bool UpdateDetails(string username, string password, string firstname, string lastname, string gender,
            int age, DateTime birthDate);

        int GetaccountId(string username);
    }
}