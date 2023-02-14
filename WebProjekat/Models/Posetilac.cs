using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Posetilac : Korisnik
    {

        public Posetilac()
        {
            GrupniTreninzi = new List<GrupniTrening>();
        }

        public Posetilac(string username, string ime, string prezime, string lozinka, string email, DateTime datumRodjenja, Role uloga, Polovi pol)
        {
            GrupniTreninzi = new List<GrupniTrening>();
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