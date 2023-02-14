using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class TrenerController : Controller
    {
        // GET: Trener
        public ActionResult Index()
        {
            Korisnik k = (Korisnik)Session["prijavljen"];

            List<GrupniTrening> tr = new List<GrupniTrening>();
            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            foreach (var item in grupniTrenings) {
                if (item.Trener == k.Username && item.IsDeleted == false && DateTime.Compare(item.DatumVreme, DateTime.Now) > 0)
                {
                    tr.Add(item);
                }
            }

            ViewBag.korisnik = k;
            ViewBag.tr = tr;
            ViewBag.c = k.angazovanjaCentri.Id;

            DateTime pom = DateTime.Now;
            DateTime d = pom.AddDays(3);

            string str = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(0,2)+"T";
            ViewBag.dan = str;
            ViewBag.mesec = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(3,2);
            ViewBag.godina = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(6,4);
            ViewBag.sati = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(11,2);
            ViewBag.minuti = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(14,2);



            return View();
        }


        public ActionResult Brisanje(string id) {

            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            Korisnik k = (Korisnik)Session["prijavljen"];

            foreach (var item in grupniTrenings) {
                
                if (item.Id == id) {
                    
                    item.IsDeleted = true;
                }
            }


            string path = "~/App_Data/GrupniTreninzi.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            k.angazovanjaTreninzi.Clear();

            foreach (var item in grupniTrenings)
            {
                k.angazovanjaTreninzi.Add(item);
                Data.SaveTrening(item);
            }

           

            return RedirectToAction("Index");


        }

        public ActionResult NoviTrening(string naziv, string tip, string fcentar, int trajanje, DateTime datumvreme, int kapacitet, bool isdeleted) {

            Korisnik k = (Korisnik)Session["prijavljen"];

            foreach (var item in k.angazovanjaTreninzi) {

                if (DateTime.Compare(item.DatumVreme, datumvreme) == 0)
                {
                    ViewBag.Message("Ne mozes stici na oba treninga");
                    return View("Greska");
                }

            }
            
            GrupniTrening gt = new GrupniTrening(naziv,tip,fcentar,trajanje,datumvreme,kapacitet,new List<string>(),isdeleted,k.Username);

            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            grupniTrenings.Add(gt);

            k.angazovanjaTreninzi.Add(gt);

            Data.SaveTrening(gt);


            return RedirectToAction("Index");
        }


        public ActionResult Izmena(string id) {

            Korisnik k = (Korisnik)Session["prijavljen"];


            foreach (var item in k.angazovanjaTreninzi) {
                if (item.Id == id)
                    ViewBag.trening = item;
                    }

          /*  DateTime d = new DateTime();

            foreach (var item in k.angazovanjaTreninzi) {
                if (item.Id == id)
                {
                    ViewBag.trening = item;
                    d = item.DatumVreme;
                }
                
            }


          string datum = d.ToLongDateString();

            ViewBag.dan = datum.Substring(0, 2);
            ViewBag.mesec = datum.Substring(3, 2);
            ViewBag.godina = datum.Substring(6, 4);
            ViewBag.sati = datum.Substring(11, 2);
            ViewBag.minuti = datum.Substring(14, 2);*/

            return View("Izmena");
        }

        public ActionResult Izmeni(string id) {

            Korisnik k = (Korisnik)Session["prijavljen"];
            List<GrupniTrening> lista = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            DateTime pom = DateTime.Now;
            DateTime d = pom.AddDays(3);

            string str = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(0, 2) + "T";
            ViewBag.dan = str;
            ViewBag.mesec = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(3, 2);
            ViewBag.godina = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(6, 4);
            ViewBag.sati = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(11, 2);
            ViewBag.minuti = d.ToString("dd/MM/yyyy HH:mm:ss").Substring(14, 2);

            string stari = "";
            foreach (var item in lista)
            {
                if (item.Id == id)
                {
                    ViewBag.trening = item;
                    stari = item.DatumVreme.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }


            string str2 = stari.Substring(0, 2) + "T";
            ViewBag.staridan = str2;
            ViewBag.starimesec = stari.Substring(3, 2);
            ViewBag.staragodina = stari.Substring(6, 4);
            ViewBag.starisat = stari.Substring(11, 2);
            ViewBag.starimin = stari.Substring(14, 2);

            //ViewBag.trening = lista[1];

            return View();
        }

        public ActionResult Izmenjen(string naziv, string tip, string fcentar, int trajanje, DateTime datumvreme, int kapacitet, bool isdeleted, string id) {

            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = (Korisnik)Session["prijavljen"];


            List<string> pomocna = new List<string>();

            foreach (var item in grupniTrenings) {
                
                if (item.Id == id) {
                    item.Naziv = naziv;
                    item.Tip = tip;
                    item.FCentar = fcentar;
                    item.TrajanjeTreninga = trajanje;
                    item.DatumVreme = datumvreme;
                    item.Kapacitet = kapacitet;
                    item.IsDeleted = isdeleted;

                        }
            }

            k.angazovanjaTreninzi.Clear();

            string path = "~/App_Data/GrupniTreninzi.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            foreach (var item in grupniTrenings)
            {
                k.angazovanjaTreninzi.Add(item);
                Data.SaveTrening(item);
            }


            return RedirectToAction("Index");
        }

        public ActionResult Prijavljeni(string id) {

            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];

            foreach (var item in grupniTrenings) {
                if (item.Id == id) {  //prazna lista
                    if (item.Spisak.Count > 0)
                        ViewBag.spisak = item.Spisak;
                    else
                        ViewBag.spisak = "";
                }

            }

            return View();

        }

    }
}