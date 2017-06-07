using System;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Interfaces
{
    public interface IPersonSqlContext
    {

        bool UpdateDetails(int id, Person person);

        //int GetaccountId(string username);
        Person GetPersonDetails(int id);
    }
}