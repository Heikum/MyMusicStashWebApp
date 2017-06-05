using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class AccountController : Controller
    {
         AccountRepository repo = new AccountRepository(new AccountSqlContext());
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
        public ActionResult Login(FormCollection collection)
        {
            Account account = new Account(collection["username"], collection["password"]);
            Session["Username"] = account.Username1;
            if (repo.Login(account))
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
           
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var birthdate = Convert.ToDateTime(collection["birthdate"]);
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;
            Person person = new Person(collection["firstname"], collection["lastname"], Convert.ToDateTime(collection["birthdate"]), age, collection["gender"]);
            Account account = new Account(collection["username"], collection["password"], person);
            try
            {
                // TODO: Add insert logic here
                repo.Register(account); 
                //Models.Email mail = new Models.Email("Activeer uw account", "inhoud", "dhrlaaboudi@gmail.com");
                //EmailLogic.SendEmail(mail);
                //EmailLogic.SendEmailNew(mail, account.Activatiehash, account.Voornaam);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                throw;
                //return View();
            }
        }
    }

    }
