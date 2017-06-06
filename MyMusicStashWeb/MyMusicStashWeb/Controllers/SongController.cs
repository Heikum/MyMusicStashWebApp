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
            collectie = repo.GetAllSongsFromUser(Convert.ToInt32(Session["UserID"]));
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
            Song song = new Song(Convert.ToInt32(Session["UserID"]), collection["MusicType"], collection["MusicName"],
                collection["ArtistName"], collection["AlbumName"], Convert.ToDateTime(collection["MusicDate"]),
                collection["MusicSource"], collection["MusicExtension"]);
            try
            {
                // TODO: Add insert logic here
                repo.AddSong(song);
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
                Song song = new Song(Convert.ToInt32(Session["UserID"]), collection["music_type"], collection["music_name"],
                    collection["artist_name"], collection["album_name"], Convert.ToDateTime(collection["music_date"]),
                    collection["music_source"], collection["music_extension"]);
                // TODO: Add update logic here
                repo.EditSong(id, song);

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
                repo.DeleteSong(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
