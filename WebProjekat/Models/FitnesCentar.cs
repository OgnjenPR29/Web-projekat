using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentar
    {
        public FitnesCentar(string naziv, Adress adresa, int godinaOtvaranja, string posednik, int cenaMesecno, int cenaGodisnje, int cenaSamostalno, int cenaGrupno, int cenaSaTrenerom, bool isdeleted)
        {
            Naziv = naziv;
            Adresa = adresa;
            GodinaOtvaranja = godinaOtvaranja;
            Posednik = posednik;
            CenaMesecno = cenaMesecno;
            CenaGodisnje = cenaGodisnje;
            CenaSamostalno = cenaSamostalno;
            CenaGrupno = cenaGrupno;
            CenaSaTrenerom = cenaSaTrenerom;
            IsDeleted = isdeleted;
        }

        public FitnesCentar() {
        }

        public string Id {
            get {
                return Naziv + " " + Adresa.Ulica + " " + Adresa.Mesto;
            }
        }
        public string Naziv { get; set; }
        public Adress Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        public string Posednik { get; set; }
        public int CenaMesecno { get; set; }
        public int CenaGodisnje { get; set; }
        public int CenaSamostalno { get; set; }
        public int CenaGrupno { get; set; }
        public int CenaSaTrenerom { get; set; }
        public bool IsDeleted { get; set; }



    }
}