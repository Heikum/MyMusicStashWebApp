using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class PersonController : Controller
    {
        PersonRepository repo = new PersonRepository(new PersonSqlContext());
        // GET: Person
        public ActionResult Index()
        {
            Person person = repo.GetPersonDetails(Convert.ToInt32(Session["UserID"]));
            return View(person);
        }

        // GET: Person/Details/5


        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Person person = repo.GetPersonDetails(Convert.ToInt32(Session["UserID"]));
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Person person = new Person(collection["Firstname1"], collection["Lastname1"], Convert.ToDateTime(collection["BirDateTime1"]), Convert.ToInt32(collection["Age1"]), collection["Gender1"]);
                repo.UpdateDetails(Convert.ToInt32(Session["UserID"]), person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
