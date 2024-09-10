using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E17GenericiMalbdaEkstenzije
{
    internal class Smjer:Entitet,ISucelje,IComparable<Smjer>
    {

        public int Sifra { get; set; }
        public string Naziv { get; set; }

        public int CompareTo(Smjer? other)
        {
            return Sifra == other?.Sifra ? 0 : Sifra > other?.Sifra ? 1 : -1;
        }

        public void Posao()
        {
            Console.WriteLine("Odrađujem posao na Smjeru");
        }

    }
}
