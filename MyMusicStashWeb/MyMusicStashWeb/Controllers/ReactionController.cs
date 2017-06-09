using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.database_Acces_layer;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class ReactionController : Controller
    {
        ReactionRepository reporeaction = new ReactionRepository(new ReactionSqlContext());
        // GET: Reaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reaction/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                Reaction reaction = new Reaction(Convert.ToInt32(Session["UserID"]), id, collection["Post"]);
                reporeaction.InsertReaction(reaction); 

                return RedirectToAction("Index");
            }
            catch
            {
                throw; 
                return View();
            }
        }

        // GET: Reaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
