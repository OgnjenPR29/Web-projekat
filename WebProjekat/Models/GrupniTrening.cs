using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class GrupniTrening
    {

        public GrupniTrening(string naziv, string tip, string fCentar, int trajanjeTreninga, DateTime datumVreme, int kapacitet, List<string> spisak, bool isDeleted, string trener)
        {
            Naziv = naziv;
            Tip = tip;
            FCentar = fCentar;
            TrajanjeTreninga = trajanjeTreninga;
            DatumVreme = datumVreme;
            Kapacitet = kapacitet;
            Spisak = spisak;
            IsDeleted = isDeleted;
            Trener = trener;
        }

        public GrupniTrening() { }

        public string Naziv { get; set; }
        public string Trener { get; set; }
        public string Tip { get; set; }
        public string FCentar { get; set; }
        public int TrajanjeTreninga { get; set; }
        public DateTime DatumVreme{ get; set; }
        public int Kapacitet { get; set; }
        public List<string> Spisak { get; set; }
        public bool IsDeleted { get; set; }

        public string Id {
            get {
                return Naziv + " " + FCentar + " " + DatumVreme ;

            }
        }

        
    }
}