using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Email;
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
            Account account = repo.GetById(Convert.ToInt32(Session["UserID"]));
            return View(account);
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
                int ID = repo.GetaccountId(collection["username"]);
                if (repo.Login(account) == true && repo.CheckActivationStatus(ID) == true)
                {
                    Session["Username"] = account.Username1;
                    Session["UserID"] = repo.GetaccountId(account.Username1);
                    return RedirectToAction("Index", "Home");

                }
                else if (repo.Login(account) == true && repo.CheckActivationStatus(ID) == false)
                {
                    TempData["NotActivated"] = "NotActivated";
                    return View();
                }
                else
                {
                    TempData["Login"] = "Wrong login";
                    return View();
                }
            
      
        }

        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Activate(FormCollection collection)
        {
            try
            {
                int accountId = repo.GetaccountId(collection["username"]);
                if (repo.CheckHash(accountId, collection["activationhash"]))
                {
                    TempData["Activated"] = "Activated";
                }
                return View(); 
            }
            catch (Exception)
            {
                TempData["Activatedfailed"] = "failed";
                return View(); 
                throw;
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

        public ActionResult Edit(int id)
        {
            Account account = repo.GetById(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            Account account = new Account(collection["Username1"], collection["Password1"], Convert.ToInt32(Session["UserID"]), collection["Email1"]);
            try
            {
                repo.EditAccount(account);

                return RedirectToAction("Index", "Account");
            }
            catch
            {
                throw;
                //return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //berekend age 
            var birthdate = Convert.ToDateTime(collection["birthdate"]);
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;

            //maakt person en account aan
            Person person = new Person(collection["firstname"], collection["lastname"], Convert.ToDateTime(collection["birthdate"]), age, collection["gender"]);
            Account account = new Account(collection["username"], collection["password"], collection["Email"], person, Email.MD5.CreateMD5(collection["Email"]), 0);
            try
            {
                repo.Register(account);
                repo.InserPerson(account); 
                Email.Email mail = new Email.Email("Activeer uw account", "inhoud", "dhrlaaboudi@gmail.com");
                EmailLogic.SendEmailNew(mail, account.ActivationHash1, account.Person.Firstname1);

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
