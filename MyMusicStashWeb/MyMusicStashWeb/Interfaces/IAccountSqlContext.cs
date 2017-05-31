using System;

namespace MyMusicStashWeb.Interfaces
{
    public interface IAccountSqlContext
    {
        bool Inloggen(string gebruikersnaam, string wachtwoord);
        int GetaccountId(string username);

        bool Registreer(string username, string password, string firstname, string lastname, string gender,
            int age, DateTime registerDateTime, DateTime birthDate);

        bool DeleteAccount(int accountId);
    }
}