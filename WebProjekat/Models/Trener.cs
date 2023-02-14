using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Trener : Korisnik
    {

        public Trener()
        {
            angazovanjaTreninzi = new List<GrupniTrening>();
            angazovanjaCentri = new FitnesCentar();
        }

        public Trener(string username, string ime, string prezime, string lozinka, string email, DateTime datumRodjenja, Role uloga, Polovi pol)
        {
            angazovanjaTreninzi = new List<GrupniTrening>();
            angazovanjaCentri = new FitnesCentar();
            Username = username;
            Prezime = prezime;
            Ime = ime;
            Lozinka = lozinka;
            Email = email;
            DatumRodjenja = datumRodjenja;
            Uloga = uloga;
            Pol = pol;
        }

    }
}