using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E15KlasaObjekt
{
    internal class Program
    {


        public static void Izvedi()
        {
            Console.WriteLine("Hello OOP");

            //Objekt je instanca(pojavnost) klase

            //Osoba je ime klase
            //osoba je ime objekta(instance/pojavnosti)-arijabla
            Osoba osoba; //deklariran, bez instance
            osoba = new Osoba(); // konstruiranje objekta -  Rađa se
            osoba.Ime = "Pero"; // objekt živi i posjeduje vrijednosti-postavljamo ih
            Console.WriteLine(osoba.Ime);// objekt žiivi i posjeduje vrijednosti koje se konzumiraju
            //a kraju objekt(osoba) umire - uništava ga/čisti iz memorije
            // mi ne uništavamo objekt, to radi Grabagge collector
            osoba.Prezime = "Perić";

            Console.WriteLine(osoba.ImePrezime()); //metoda ImePrezime nije statična jer nju ne zovem na objektu

            //drugi načini kreiranja objekta

            Osoba ravnatelj = new Osoba
            {
                Sifra = 1,
                Ime="Marko",
                Prezime="Kas"

            };

            var direktor = new Osoba { Ime = "Edo" }; //dobra praksa

            Osoba profesor = new() { Prezime = "Reh", Ime="Klara" };

            Console.WriteLine(profesor.Ime?.ToUpper());

            var o = new Osoba()
            {
                Ime = "Marija",
                Mjesto = new() { Naziv = "Osijek", PostanskiBroj = "31000" }
            };

            Console.WriteLine(o.Mjesto?.Naziv?.ToUpper());




            //dugi način
            Zupanija obz=new Zupanija();
            obz.Naziv = "Osječko-baranjska županija";
            
            Mjesto os=new Mjesto();
            os.Naziv = "Osijek";

            os.Zupanija = obz;

            Osoba ja=new Osoba();
            ja.Ime = "Tomislav";
            ja.Mjesto = os;

            //Ispišite u konzoli iz objekta o vrijednost Osječko-baranjska županija
            Console.WriteLine(ja.Mjesto?.Zupanija?.Naziv);

            



        }
    }
}
