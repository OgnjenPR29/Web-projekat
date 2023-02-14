using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Kometar
    {
        public Kometar(string komentarisao, string centar, string tekst, int ocena, bool odobren)
        {
            Komentarisao = komentarisao;
            Centar = centar;
            Tekst = tekst;
            Ocena = ocena;
            Odobren = odobren;
        }

        public string Komentarisao { get; set; }
        public string Centar { get; set; }
        public string Tekst { get; set; }
        public int Ocena { get; set; }
        public bool Odobren { get; set; }

    }
} 