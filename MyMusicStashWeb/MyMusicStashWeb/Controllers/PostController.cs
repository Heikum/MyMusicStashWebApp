using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.database_Acces_layer;
using MyMusicStashWeb.Interfaces;
using MyMusicStashWeb.Models;

namespace MyMusicStashWeb.Controllers
{
    public class PostController : Controller
    {
        PostRepository repopost = new PostRepository(new PostsqlContext());
        ReactionRepository reporeaction = new ReactionRepository(new ReactionSqlContext());
        // GET: Post

        public ActionResult Index()
        {
            List<Post> posts = new List<Post>();
            posts = repopost.GetAllPosts();
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Reactions(int id)
        {
            List<Reaction> listreaction = reporeaction.GetSpecificReactions(id); 
            return View(listreaction);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Post post = new Post(Convert.ToInt32(Session["UserID"]), collection["Posttext"]);
                // TODO: Add insert logic here
                repopost.InsertPost(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
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

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            //Post post = repopost.
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Post post = new Post(id);
            try
            {
                // TODO: Add delete logic here
                repopost.DeletePost(post); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
