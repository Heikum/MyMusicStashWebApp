using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.Database_Acces_Layer;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class MediaController : Controller
    {
        MediaRepository repo = new MediaRepository(new MediaSqlContext());
        // GET: Media
        public ActionResult Index()
        {
            List<Media> medialList = new List<Media>();
            medialList = repo.GetAllMedia(); 
            return View(medialList);
        }

        // GET: Media/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVideo(FormCollection collection)
        {
            try
            {
                Video video = new Video(collection["VideoUrl1"], 1, Convert.ToInt32(Session["UserID"]), DateTime.Now, "Video");
                repo.InsertMedia(video);

                return RedirectToAction("Index", "Media");
            }
            catch
            {
                throw;
                TempData["WrongInput"] = "Wrong";
                return View();
            }
        }

        // GET: Media/Create
        public ActionResult CreateImage()
        {
            return View();
        }

        // POST: Media/Create
        [HttpPost]
        public ActionResult CreateImage(FormCollection collection)
        {
            try
            {
                Image image = new Image(collection["ImageUrl1"], 1, Convert.ToInt32(Session["UserID"]), DateTime.Now, "Image");
                repo.InsertMedia(image);

                return RedirectToAction("Index", "Media");
            }
            catch
            {
                throw;
                TempData["WrongInput"] = "Wrong";
                return View();
            }
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Media/Edit/5
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

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            Media media = repo.Getmedia(id);
            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repo.DeleteMedia(id); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
