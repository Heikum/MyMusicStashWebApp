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
            Session["UserID"] = repo.GetaccountId(account.Username1); 
            if (repo.Login(account))
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
           
        }
        //zorgt voor het uitloggen van de gebruiker door zowel de sessie te clearen als de cookies te verwijderen indien aanwezig
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Response.AddHeader("Cache-Control", "no-cache, no-store,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Session.Abandon();

            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["Username"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
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
