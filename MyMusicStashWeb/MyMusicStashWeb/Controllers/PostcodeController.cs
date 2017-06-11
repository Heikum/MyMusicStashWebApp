using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicStashWeb.PostcodeApi;
using PostcodeAPI.V2.Wrappers;

namespace MyMusicStashWeb.Controllers
{
    public class PostcodeController : Controller
    {
        Client postcodeclient = new Client();

        // GET: Postcode
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAdress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAdress(FormCollection collection)
        {
            Adresgegevens adres = new Adresgegevens(Convert.ToInt32(collection["Huisnummer"]), collection["Postcode"]);
            ApiHalResultWrapper result1 = postcodeclient.GetAdress(adres);
            Session["Adres"] = result1.Embedded.Addresses[0].Street;
            return View();
        }

    }
}