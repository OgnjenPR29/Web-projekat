using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            Korisnik k = (Korisnik)Session["prijavljen"];
            ViewBag.korisnik = k;

            string datumrodjenja = k.DatumRodjenja.ToString("dd/MM/yyyy");

            ViewBag.dan = datumrodjenja.Substring(0, 2);
            ViewBag.mesec = datumrodjenja.Substring(3, 2);
            ViewBag.godina = datumrodjenja.Substring(6, 4);

            return View();
        }


        [HttpPost]
        public ActionResult Izmenjen(Korisnik k) {

            Korisnik user = (Korisnik)Session["prijavljen"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            var index = korisnici.FindIndex(o => o.Username == user.Username);
            korisnici[index] = k;
            
            Session["prijavljen"] = null;
            Session["prijavljen"] = k;

            string path = "~/App_Data/RegistrovaniKorisnici.txt";
            path = HostingEnvironment.MapPath(path);
            System.IO.File.WriteAllText(path, string.Empty);

            foreach (var item in korisnici)
            {
                Data.SaveUser(item);
            }

            return RedirectToAction("Profil", "Home");

        }


    }
}