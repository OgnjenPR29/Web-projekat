using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Vlasnik : Korisnik
    {

        public Vlasnik()
        {
            centri = new List<FitnesCentar>();
        }

        public Vlasnik(string username, string ime, string prezime, string lozinka, string email, DateTime datumRodjenja, Role uloga, Polovi pol)
        {
            centri = new List<FitnesCentar>();
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