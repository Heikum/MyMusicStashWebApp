using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.database_Acces_layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;
using MyMusicStashWeb.Repository_s;

namespace MyMusicStashWeb.Controllers
{
    public class SongController : Controller
    {
        SongRepository repo = new SongRepository(new SongSQLContext());

        // GET: Song
        public ActionResult Index()
        {
            List<Song> collectie = new List<Song>();
            collectie = repo.GetAllSongs();
            return View(collectie);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Song/Edit/5
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

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Song/Delete/5
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
