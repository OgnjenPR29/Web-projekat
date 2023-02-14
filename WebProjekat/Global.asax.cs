using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebProjekat.Models;

namespace WebProjekat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            List<FitnesCentar> fcentri = Data.ReadFitnesCentres("~/App_Data/FitnesCentri.txt");
            HttpContext.Current.Application["fcentri"] = fcentri;

            List<Korisnik> korisnici = Data.ReadUsers("~/App_Data/RegistrovaniKorisnici.txt");
            HttpContext.Current.Application["korisnici"] = korisnici;

            List<GrupniTrening> gtreninzi = Data.ReadGrupniTreninzi("~/App_Data/GrupniTreninzi.txt");
            HttpContext.Current.Application["gtreninzi"] = gtreninzi;

            List<Kometar> komentari = Data.ReadKomentari("~/App_Data/komentari.txt");
            HttpContext.Current.Application["komentari"] = komentari;
        }
    }
}
