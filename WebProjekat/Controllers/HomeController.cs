using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<FitnesCentar> pomocna= new List<FitnesCentar>();
            //dodavanje u listu
            Korisnik user = (Korisnik)Session["prijavljen"];
            

            if (Session["prijavljen"] == null) {
                ViewBag.Message = "";

            }
            else if (user.Uloga.ToString() == "Posetilac")
            {
                ViewBag.Message = "Posetilac";
            }
            else if (user.Uloga.ToString() == "Trener")
            {
                ViewBag.Message = "Trener";
            }
            else {
                ViewBag.Message = "Vlasnik";
            }

            foreach (var item in fitnesCentri) {

                if (item.IsDeleted == false)
                    pomocna.Add(item);

            }

            List<FitnesCentar> SortedList = pomocna.OrderBy(o => o.Naziv).ToList();

            ViewBag.fitnesCentri = SortedList;

            return View();
        }

        [HttpPost]
        public ActionResult Detalji(string id) {

            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<Kometar> komentari = (List<Kometar>)HttpContext.Application["komentari"];

            List<GrupniTrening> proslediti = new List<GrupniTrening>();
            List<Kometar> kom = new List<Kometar>();

            foreach (var i in fitnesCentri) {
                if (i.Id==id) {

                    ViewBag.details = i;
                }
            }


            foreach (var j in grupniTreninzi)
            {
                if (j.FCentar == id && j.IsDeleted == false && DateTime.Compare(j.DatumVreme,DateTime.Now) > 0)
                {
                    proslediti.Add(j);
                }
            }


            foreach (var item in komentari)
            {
                if (item.Centar == id && item.Odobren == true)
                {
                    kom.Add(item);
                }
            }

            ViewBag.treninzi = proslediti;
            ViewBag.komentari = kom;

            return View();
        }

        public ActionResult Registracija() {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut() {

            Session["prijavljen"] = null;

            return RedirectToAction("Index");
        }

        public ActionResult Profil()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            Korisnik k = (Korisnik)Session["prijavljen"];

            if(k.Uloga.ToString() == "Trener") {
                List<GrupniTrening> gtT = new List<GrupniTrening>();
                List<GrupniTrening> gtP = new List<GrupniTrening>();
                foreach (var item in grupniTreninzi)
                {
                    if (item.Trener == k.Username && DateTime.Compare(item.DatumVreme,DateTime.Now)<0) {
                        gtT.Add(item);
                    }
                    if (item.Trener == k.Username && DateTime.Compare(item.DatumVreme, DateTime.Now) > 0) {
                        gtP.Add(item);
                    }
                }
                ViewBag.korisnik = k;
                ViewBag.gt = gtT;
                ViewBag.gtP = gtP;
                return View("ProfilTrener");
            }

            if (k.Uloga.ToString() == "Posetilac") {

                 List<GrupniTrening> gt = new List<GrupniTrening>();
                 foreach (var item in grupniTreninzi) {
                     if (item.Spisak.Contains(k.Username) && DateTime.Compare(item.DatumVreme,DateTime.Now)<0) {
                         gt.Add(item);
                     }
                 }

                 ViewBag.gt = gt;

             }

            ViewBag.korisnik = k;

            return View();
        }

    }
}