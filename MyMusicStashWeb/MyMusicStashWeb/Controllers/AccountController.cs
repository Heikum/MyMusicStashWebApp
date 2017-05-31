using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class AccountController : Controller
    {
        public AccountRepository repo = new AccountRepository(new AccountSqlContext());
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (repo.Inloggen(username, password))
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Register(Account account, Person person)
        {
            if (repo.Registreer(account.Username1, account.Password1, person.Firstname1, person.Lastname1,
                person.Gender1, person.Age1, DateTime.Now, person.BirDateTime1))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}