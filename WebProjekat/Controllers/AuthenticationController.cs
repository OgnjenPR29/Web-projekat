using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Registrovan(Korisnik user)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            bool username = false;

            foreach (var item in korisnici) {
                if (item.Username == user.Username)
                    username = true;
            }

            if (username)
            {
                ViewBag.Message = $"User with {user.Username} already exists!";
                return View("GreskaUsername");
            }
            
            Data.SaveUser(user);
            korisnici.Add(user);
            Session["prijavljen"] = user;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Loginovan(string username, string lozinka)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik user = korisnici.Find(u => u.Username.Equals(username) && u.Lozinka.Equals(lozinka));

            if (user == null)
            {
                ViewBag.Message = $"User with credentials does not exist!";
                return View("GreskaUsername");
            }

            List<string> zabrana = Data.ReadZabrana("~/App_Data/Zabrana.txt");

            if (zabrana.Contains(username)) {
                ViewBag.Message = $"NEMATE PRAVO PRISTUPA SAJTU, NE RADITE NI U JEDNOM FITNES CENTRU";
                return View("GreskaUsername");
            }

            Session["prijavljen"] = user;
            return RedirectToAction("Index", "Home");
        }

    }
}