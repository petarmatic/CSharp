using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal class Predavac:Osoba
    {

        public Predavac() { }
        public Predavac(int sifra, string ime, string prezime, string IBAN) 
        {
            base.Sifra = sifra;
            base.Ime = ime;
            base.Prezime = prezime;
            this.IBAN = IBAN;
        
        }
        public string? IBAN { get; set; }



    }
}
