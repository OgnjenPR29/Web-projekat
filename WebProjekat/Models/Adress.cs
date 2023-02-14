using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Adress
    {

        public Adress(string ulica, string mesto, int postanskiBroj)
        {
            Ulica = ulica;
            Mesto = mesto;
            PostanskiBroj = postanskiBroj;
        }


        public string Ulica { get; set; }
        public string Mesto { get; set; }
        public int PostanskiBroj { get; set; }

    }
}