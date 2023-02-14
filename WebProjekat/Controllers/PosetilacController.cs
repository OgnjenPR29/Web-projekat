using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class PosetilacController : Controller
    {
        // GET: Posetilac
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalji(string id) {


            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<Kometar> komentari = (List<Kometar>)HttpContext.Application["komentari"];

            List<GrupniTrening> proslediti = new List<GrupniTrening>();
            List<Kometar> kom = new List<Kometar>();

            foreach (var i in fitnesCentri)
            {
                if (i.Id == id)
                {
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

            return View("Detalji");
        }

        public ActionResult TreningPrijava(string id) {

            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            Korisnik k = (Korisnik)Session["prijavljen"];

            foreach (var item in grupniTreninzi) {

                if (item.Id == id)
                {
                    if (item.Spisak.Contains(k.Username)) {
                        ViewBag.Message = "Vec ste se prijavili na taj trening";
                        return View("GreskaPrijaveNaTrening");
                    }
                    else if (item.Spisak.Count + 1 > item.Kapacitet) {
                        ViewBag.Message = "Popunjen broj mesta za taj trening";
                        return View("GreskaPrijaveNaTrening");
                    }
                    item.Spisak.Add(k.Username);
                    k.GrupniTreninzi.Add(item);
                }
            }

            string path = "~/App_Data/GrupniTreninzi.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            foreach (var item in grupniTreninzi) {
                Data.SaveTrening(item);
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Komentar(string tekst, string centar, string ocena, string odobren) {

            List<Kometar> komentari = (List<Kometar>)HttpContext.Application["komentari"];
            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            Korisnik k = (Korisnik)Session["prijavljen"];
            int count = 0;
            bool ucestvovao = false;

            foreach (var i in grupniTrenings) {
                if (centar == i.FCentar) {
                    count++;
                    if (i.Spisak.Contains(k.Username))
                    {
                        ucestvovao = true;
                        break;
                    }

                }
             }
            if (count==0) {
                ViewBag.Message = "Da biste mogli da komentarisete neophodno je da ste posetili " + centar + ".";
                return View("GreskaPrijaveNaTrening");

            }
            if (!ucestvovao) {
                ViewBag.Message = "Da biste mogli da komentarisete neophodno je da ste posetili " + centar + ".";
                return View("GreskaPrijaveNaTrening");
            }

            string komentarisao = k.Username;

            Kometar kom = new Kometar(komentarisao,centar, tekst,int.Parse(ocena),bool.Parse(odobren));

            komentari.Add(kom);

            string path = "~/App_Data/komentari.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            foreach (var item in komentari)
            {
                Data.SaveKometar(item);
            }
            

            return RedirectToAction("Index","Home");//za sad
        }

    }
}