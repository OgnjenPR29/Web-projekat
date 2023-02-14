using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebProjekat.Models
{
    public class Data
    {
        public static List<FitnesCentar> ReadFitnesCentres(string path)
        {
            List<FitnesCentar> centri = new List<FitnesCentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                Adress a = new Adress(tokens[1],tokens[2],int.Parse(tokens[3]));

                FitnesCentar p = new FitnesCentar(tokens[0], a, int.Parse(tokens[4]), tokens[5], int.Parse(tokens[6]), int.Parse(tokens[7]), int.Parse(tokens[8]), int.Parse(tokens[9]), int.Parse(tokens[10]), bool.Parse(tokens[11]));
                centri.Add(p);
            }
            sr.Close();
            stream.Close();

            return centri;
        }

        public static List<Korisnik> ReadUsers(string path)
        {
            List<Korisnik> users = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                if (tokens[6] == "Vlasnik")
                {
                    List<FitnesCentar> centri = ReadFitnesCentres("~/App_Data/FitnesCentri.txt");
                    string pom = tokens[5];
                    Vlasnik k = new Vlasnik(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], DateTime.ParseExact(tokens[5], "dd/MM/yyyy", CultureInfo.CurrentCulture), (Role)Enum.Parse(typeof(Role), tokens[6]), (Polovi)Enum.Parse(typeof(Polovi), tokens[7]));

                    foreach (var item in centri)
                    {
                        if (item.Posednik == tokens[0])
                        {
                            k.centri.Add(item);
                        }
                    }

                    users.Add(k);
                }

                else if (tokens[6] == "Posetilac")
                {
                    List<GrupniTrening> treninzi = ReadGrupniTreninzi("~/App_Data/GrupniTreninzi.txt");
                    Posetilac p = new Posetilac(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], DateTime.ParseExact(tokens[5], "dd/MM/yyyy", CultureInfo.CurrentCulture), (Role)Enum.Parse(typeof(Role), tokens[6]), (Polovi)Enum.Parse(typeof(Polovi), tokens[7]));

                    foreach (var item in treninzi)
                    {

                        if (item.Spisak.Contains(tokens[0]))
                        {
                            p.GrupniTreninzi.Add(item);
                        }

                    }

                    users.Add(p);

                }

                else {

                    List<GrupniTrening> treninzi = ReadGrupniTreninzi("~/App_Data/GrupniTreninzi.txt");
                    List<FitnesCentar> centri = ReadFitnesCentres("~/App_Data/FitnesCentri.txt");
                    List<string> veza = ReadTrenerCentar("~/App_Data/TrenerCentar.txt");

                    string pomocna = "";

                    foreach (var item in veza) {
                        if (item.StartsWith(tokens[0])) {
                            pomocna = item.Split(';')[1];
                        }
                    }


                    Trener t = new Trener(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], DateTime.ParseExact(tokens[5], "dd/MM/yyyy", CultureInfo.CurrentCulture), (Role)Enum.Parse(typeof(Role), tokens[6]), (Polovi)Enum.Parse(typeof(Polovi), tokens[7]));

                    foreach (var item in treninzi)
                    {
                        if (item.Trener == tokens[0])
                        {
                            t.angazovanjaTreninzi.Add(item);
                        }
                    }


                    foreach (var item in centri)
                    {
                        if (item.Id == pomocna)
                            t.angazovanjaCentri = item;

                    }


                    users.Add(t);

            }


            }
            sr.Close();
            stream.Close();

            return users;
        }

        public static List<string> ReadTrenerCentar(string putanja) {

            List<string> veze = new List<string>();
            putanja = HostingEnvironment.MapPath(putanja);
            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                veze.Add(line);

            }


            sr.Close();
            stream.Close();

            return veze;


        }

        public static List<string> ReadZabrana(string putanja)
        {

            List<string> zabrana = new List<string>();
            putanja = HostingEnvironment.MapPath(putanja);
            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                zabrana.Add(line);

            }


            sr.Close();
            stream.Close();

            return zabrana;


        }

        public static List<GrupniTrening> ReadGrupniTreninzi(string path)
        {
            List<GrupniTrening> grupniTreninzi = new List<GrupniTrening>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {

                string[] tokens = line.Split(';');

                List<string> result = tokens[6].Split(',').ToList();
                if (result[0] == "")
                {
                    result.Clear();
                }

                GrupniTrening k = new GrupniTrening(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]), DateTime.ParseExact(tokens[4], "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture), int.Parse(tokens[5]), result, bool.Parse(tokens[7]),tokens[8]);

                grupniTreninzi.Add(k);
            }
            sr.Close();
            stream.Close();

            return grupniTreninzi;
        }

        public static List<Kometar> ReadKomentari(string path)
        {
            List<Kometar> kom = new List<Kometar>();
            path = HostingEnvironment.MapPath(path);

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {

                string[] tokens = line.Split(';');

                Kometar k = new Kometar(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]), bool.Parse(tokens[4]));

                kom.Add(k);
            }
            sr.Close();
            stream.Close();

            return kom;
        }




        public static void SaveUser(Korisnik user)
        {
            string path = "~/App_Data/RegistrovaniKorisnici.txt";

            string date = user.DatumRodjenja.ToString("dd/MM/yyyy");
            string date2 = date.Replace('.', '/');

            string str = user.Username + ";" + user.Ime + ";" + user.Prezime + ";" + user.Lozinka + ";" + user.Email + ";" + date2 + ";" + user.Uloga.ToString() + ";" + user.Pol.ToString();


            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

            // save user in file users.txt
        }

        public static void SaveTrening(GrupniTrening trening)
        {
            string path = "~/App_Data/GrupniTreninzi.txt";

            string lista = "";

            if (trening.Spisak.Count > 0)
            {
                foreach (var item in trening.Spisak)
                {
                    lista = lista + item + ",";
                }
            }
            else {
                lista = "";
            }

            if (lista.Length > 0)
            {
                lista = lista.Remove(lista.Length - 1);
            }


            string str = trening.Naziv + ";" + trening.Tip + ";" + trening.FCentar + ";" + trening.TrajanjeTreninga.ToString() + ";" + trening.DatumVreme.ToString("dd/MM/yyyy HH:mm:ss").Replace('.', '/') + ";" + trening.Kapacitet + ";" + lista + ";" + trening.IsDeleted + ";" + trening.Trener;

            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

            // save user in file users.txt
        }

        public static void SaveKometar(Kometar komentar)
        {
            string path = "~/App_Data/komentari.txt";
            
            string str = komentar.Komentarisao + ";" + komentar.Centar + ";" + komentar.Tekst + ";" + komentar.Ocena.ToString() + ";" + komentar.Odobren.ToString();

            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

            // save user in file users.txt
        }

        public static void SaveVeza(string str) {
            string path = "~/App_Data/TrenerCentar.txt";

            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

        }

        public static void SaveZabrana(string str)
        {
            string path = "~/App_Data/Zabrana.txt";

            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

        }

        public static void SaveCentar(FitnesCentar fc)
        {
            string path = "~/App_Data/FitnesCentri.txt";

            string str = fc.Naziv + ";" + fc.Adresa.Ulica + ";" + fc.Adresa.Mesto + ";" + fc.Adresa.PostanskiBroj.ToString() + ";" + fc.GodinaOtvaranja.ToString() + ";" + fc.Posednik + ";" + fc.CenaMesecno.ToString() + ";" + fc.CenaGodisnje.ToString() + ";" + fc.CenaSamostalno.ToString() + ";" + fc.CenaGrupno.ToString() + ";" + fc.CenaSaTrenerom.ToString() + ";" + fc.IsDeleted.ToString();

            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(str);

            sw.Close();
            stream.Close();

        }

    }
}