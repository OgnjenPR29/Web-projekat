using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Korisnik
    {
        public List<GrupniTrening> GrupniTreninzi = new List<GrupniTrening>();
        public List<FitnesCentar> centri = new List<FitnesCentar>();

        public List<GrupniTrening> angazovanjaTreninzi = new List<GrupniTrening>();
        public FitnesCentar angazovanjaCentri = new FitnesCentar();


        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Role Uloga { get; set; }
        public Polovi Pol { get; set; }

    }     
}