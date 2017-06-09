using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMusicStashWeb;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace UnitTestProjectMyMusicStash.Tests
{
    [TestClass]
    public class PostSQLContextTests
    {
        AccountRepository repository = new AccountRepository(new AccountSQLContextTest());

        [TestMethod()]
        public void AccountListTest()
        {
            List<Account> accountlist = repository.GetAllAccounts();
            Account account = new Account("Heikum", "123", 5, "dhrlaaboudi@gmail.com");
            accountlist.Add(account);
            Account[] accountlijst = accountlist.ToArray();
            Assert.AreEqual("Heikum", accountlijst[0].Username1);
            Assert.AreEqual("123", accountlijst[0].Password1);
        }



        private class AccountSQLContextTest : IAccountSqlContext
        {
            private List<Account> accounts;

            public AccountSQLContextTest()
            {
                accounts = new List<Account>()
                {
                    new Account("Heikum", "123", 5, "dhrlaaboudi@gmail.com"),
                    new Account("Davey", "123", 5, "dhrlaaboudi@gmail.com"),
                    new Account("Sander", "123", 5, "dhrlaaboudi@gmail.com")
                };
            }

            public bool Login(Account account)
            {
                throw new NotImplementedException();
            }

            public int GetaccountId(string username)
            {
                throw new NotImplementedException();
            }

            public bool Register(Account account)
            {
                throw new NotImplementedException();
            }

            public bool DeleteAccount(int accountId)
            {
                throw new NotImplementedException();
            }

            public bool InsertPerson(Account acount)
            {
                throw new NotImplementedException();
            }

            public bool EditAccount(Account account)
            {
                throw new NotImplementedException();
            }

            public Account GetById(int id)
            {
                throw new NotImplementedException();
            }

            public bool CheckHash(int ID, string hash)
            {
                throw new NotImplementedException();
            }

            public bool ActivateAccount(int ID)
            {
                throw new NotImplementedException();
            }

            public bool GetActivationStatus(int ID)
            {
                throw new NotImplementedException();
            }

            public List<Account> GetAllAccounts()
            {
                return accounts; 
            }
        

        }
    }
}
