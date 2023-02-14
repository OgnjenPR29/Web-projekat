using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class VlasnikController : Controller
    {
        // GET: Vlasnik
        public ActionResult Index()
        {
            Korisnik k = (Korisnik)Session["prijavljen"];

            List<FitnesCentar> centres = new List<FitnesCentar>();

            foreach (var item in k.centri) {
                if (item.IsDeleted == false)
                    centres.Add(item);
            }

            ViewBag.centri = centres;

            return View();
        }

        public ActionResult Registrovan(Korisnik user, string fc) {

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<FitnesCentar> fcentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            FitnesCentar pomocni = new FitnesCentar();

            bool username = false;

            foreach (var item in korisnici)
            {
                if (item.Username == user.Username)
                    username = true;
            }

            if (username)
            {
                ViewBag.Message = $"User with {user.Username} already exists!";
                return View("GreskaUsername");
            }

            foreach (var item in fcentri) {
                if (item.Id == fc)
                    pomocni = item;
            }

            user.angazovanjaCentri = pomocni;

            Data.SaveVeza(user.Username + ";" + pomocni.Id);
            Data.SaveUser(user);
            korisnici.Add(user);

            return RedirectToAction("Index", "Home");

        }


        public ActionResult FCentri() {

            Korisnik k = (Korisnik)Session["prijavljen"];
            List<FitnesCentar> pomocna = new List<FitnesCentar>();

            foreach (var item in k.centri)
            {

                if (item.IsDeleted == false && item.Posednik == k.Username)
                    pomocna.Add(item);

            }
            ViewBag.centri = pomocna;
            
            ViewBag.vlasnik = k;

            return View();


        }

        public ActionResult Brisanje(string id) {

            List<GrupniTrening> grupniTrenings = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            Korisnik k = (Korisnik)Session["prijavljen"];

            foreach (var item in grupniTrenings)
            {
                if (item.FCentar == id && DateTime.Compare(item.DatumVreme, DateTime.Now) > 0)
                {
                    ViewBag.Message("NE MOZETE DA OBRISETE OVAJ FITNES CENTAR");
                    return View("Greska");
                }
            }

            foreach (var item in fitnesCentri)
            {

                if (item.Id == id)
                {

                    item.IsDeleted = true;
                }
            }

            int index = -1;
            int pomocna = 0;
            int flag = 0;

            List<string> list = Data.ReadTrenerCentar("~/App_Data/TrenerCentar.txt");
            List<string> zabranjeni = Data.ReadZabrana("~/App_Data/Zabrana.txt");

            foreach (var item in korisnici) {
                if (item.Uloga.ToString() == "Trener" && !zabranjeni.Contains(item.Username))
                {
                    string a = item.Username;
                    string b = item.angazovanjaCentri.Id;
                    if (item.angazovanjaCentri.Id == id)
                    {
                        Data.SaveZabrana(item.Username);
                        foreach (var i in list) {
                            index++;
                            if (i.StartsWith(item.Username))
                            {
                                pomocna = index;
                                flag++;
                            }
                        }

                    }
                }

            }

            if (flag > 0)
                list.RemoveAt(pomocna);


            string putanja = "~/App_Data/TrenerCentar.txt";
            putanja = HostingEnvironment.MapPath(putanja);
            System.IO.File.WriteAllText(putanja, string.Empty);

            foreach(var item in list)
            {
                Data.SaveVeza(item);
            }

            string path = "~/App_Data/FitnesCentri.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            k.centri.Clear();

            foreach (var item in fitnesCentri)
            {
                k.centri.Add(item);
                Data.SaveCentar(item);
            }



            return RedirectToAction("FCentri");


        }


        public ActionResult NoviCentar(string naziv, string ulica, string mesto, int postanskibroj, int godinaotvaranja, string posednik, int mesecno, int godisnje, int samostalno, int grupno, int strenerom, bool isdeleted) {

            Korisnik k = (Korisnik)Session["prijavljen"];
            List<FitnesCentar> fitnesCentars = (List<FitnesCentar>)HttpContext.Application["fcentri"];

            foreach (var item in fitnesCentars)
            {
                if (item.Adresa == new Adress(ulica, mesto, postanskibroj))
                {
                    ViewBag.Message = "VEC POSTOJI CENTAR SA TOM ADRESOM";
                    return View("Greska");
                }
            }

            FitnesCentar novi = new FitnesCentar(naziv, new Adress(ulica, mesto, postanskibroj), godinaotvaranja, posednik, mesecno, godisnje, samostalno, grupno, strenerom, isdeleted);

            fitnesCentars.Add(novi);
            k.centri.Add(novi);

            Data.SaveCentar(novi);

            return RedirectToAction("FCentri");

        }

        public ActionResult Izmeni(string id) {

            Korisnik k = (Korisnik)Session["prijavljen"];
            List<FitnesCentar> lista = (List<FitnesCentar>)HttpContext.Application["fcentri"];



            foreach (var item in lista)
            {
                if (item.Id == id)
                {
                    ViewBag.adresa = item.Adresa;
                    ViewBag.centar = item;
                }
            }

            return View();
        }

        public ActionResult Izmenjen(string naziv, string ulica, string mesto, int postanskibroj, int godinaotvaranja, string posednik, int cenamesecno, int cenagodisnje, int cenasamostalno, int cenagrupno, int cenasatrenerom, bool isdeleted, string id) {

            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["gtreninzi"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = (Korisnik)Session["prijavljen"];
            List<GrupniTrening> pomocni = new List<GrupniTrening>();
            List<string> pomocna = new List<string>();

            foreach (var item in fitnesCentri)
            {

                if (item.Id == id)
                {
                    item.Naziv = naziv;
                    item.Adresa = new Adress(ulica,mesto,postanskibroj);
                    item.GodinaOtvaranja = godinaotvaranja;
                    item.CenaMesecno = cenamesecno;
                    item.CenaGodisnje = cenagodisnje;
                    item.CenaSamostalno = cenasamostalno;
                    item.CenaGrupno = cenagrupno;
                    item.CenaSaTrenerom = cenasatrenerom;

                    foreach (var i in grupniTreninzi)
                    {
                        if (i.FCentar == id)
                        {
                            pomocni.Add(i);
                            i.FCentar = item.Id;

                        }
                    }

                }
            }

            foreach (var user in korisnici) {
                foreach (var item in grupniTreninzi) {
                    if (item.Spisak.Contains(user.Username)) {
                        foreach (var tr in user.GrupniTreninzi) {
                            if (tr.Id == item.Id) {
                                tr.FCentar = item.FCentar;
                            }
                        }
                    }
                }
            }
            //k.angazovanjaTreninzi.Clear();
            k.centri.Clear();

            string path = "~/App_Data/FitnesCentri.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            foreach (var item in fitnesCentri)
            {
                k.centri.Add(item);
                Data.SaveCentar(item);
            }

            string putanja = "~/App_Data/GrupniTreninzi.txt";
            putanja = HostingEnvironment.MapPath(putanja);
            System.IO.File.WriteAllText(putanja, string.Empty);

            foreach (var item in grupniTreninzi)
            {
                Data.SaveTrening(item);
            }




            return RedirectToAction("FCentri");

        }

        public ActionResult Detalji(string id) {

            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fcentri"];
            List<Kometar> komentari = (List<Kometar>)HttpContext.Application["komentari"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            List<string> trenericentri = Data.ReadTrenerCentar("~/App_data/TrenerCentar.txt");
            string[] niz;
            List<string> treneri = new List<string>();
            List<Korisnik> poslati = new List<Korisnik>();


            foreach (var i in trenericentri) {
                niz = i.Split(';');
                if (niz[1] == id) {
                    treneri.Add(niz[0]);
                }
            }

            foreach (var item in korisnici) {
                foreach (var j in treneri) {
                    if (j == item.Username) {
                        poslati.Add(item);
                    }
                }
            }

            ViewBag.treneri = poslati;

            List<Kometar> kom = new List<Kometar>();

            foreach (var i in fitnesCentri)
            {
                if (i.Id == id)
                {
                    ViewBag.details = i;
                }
            }


            foreach (var item in komentari)
            {
                if (item.Centar == id)
                {
                    kom.Add(item);
                }

            }

            Korisnik k = (Korisnik)Session["prijavljen"];

            ViewBag.komentari = kom;
            ViewBag.vlasnik = k;

            return View("Detalji");
        }

        public ActionResult Komentar(string id, string odobren) {

            List<Kometar> komentari = (List<Kometar>)HttpContext.Application["komentari"];
            string str = "";

            foreach (var item in komentari) {
                str = item.Komentarisao + " " + item.Centar + " " + item.Tekst;
                if (id == str) {
                    if (item.Odobren == true && odobren == "odbij")
                    {
                        item.Odobren = false;
                    }
                    else if (item.Odobren == false && odobren == "odobri") {
                        item.Odobren = true;
                    }
                }
            }



            string putanja = "~/App_Data/komentari.txt";
            putanja = HostingEnvironment.MapPath(putanja);
            System.IO.File.WriteAllText(putanja, string.Empty);

            foreach(var kom in komentari)
            {
                Data.SaveKometar(kom);
            }


            return RedirectToAction("Index", "Home");

        }

        public ActionResult Blokiraj(string username) {

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<string> lista = Data.ReadZabrana("~/App_Data/Zabrana.txt");
            List<string> lista2 = Data.ReadTrenerCentar("~/App_Data/TrenerCentar.txt");

            if (!lista.Contains(username))
                Data.SaveZabrana(username);

            //mozda ovo uraditi
            int index = -1;
            int pomocna = 0;

            //trener centar ispraviti
            foreach (var item in lista2) {
                index++;
                if (item.StartsWith(username)) {
                    pomocna = index;
                }
            }

            lista2.RemoveAt(pomocna);

            string putanja = "~/App_Data/TrenerCentar.txt";
            putanja = HostingEnvironment.MapPath(putanja);
            System.IO.File.WriteAllText(putanja, string.Empty);

            foreach (var item in lista2) {
                Data.SaveVeza(item);
            }

            return RedirectToAction("Index","Home");
        }


    }
}