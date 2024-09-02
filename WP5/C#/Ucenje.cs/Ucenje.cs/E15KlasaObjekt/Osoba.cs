using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E15KlasaObjekt
{
    //Klasa je opisnik objekta
    internal class Osoba
    {

        //Klasa sadrži svojstva(property)
        public int? Sifra { get; set; }//OOP princip učahurivanja
        public string? Ime { get; set; } // ? označava kako Ime može biti null
        public string? Prezime { get; set; }

        public Mjesto? Mjesto { get; set; }

        //Klasa sadrži metode
        public string ImePrezime()
        {
            return Ime + " " + Prezime;

        }



    }
}
