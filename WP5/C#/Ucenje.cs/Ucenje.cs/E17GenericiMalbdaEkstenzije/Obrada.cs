using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E17GenericiMalbdaEkstenzije
{
    internal class Obrada<T> : ISucelje where T : Entitet
    {

        public T? ObjektObrade { get; set; }
        public List<T>? ListaZaObradu { get; set; }


        public void Obradi()
        {
            Console.WriteLine(ObjektObrade?.Sifra);


        }

        public void Posao()
        {
            Console.WriteLine("Odrađujem posao u Obradi");
        }


        public void IspisStavaka(Action<T> akcija)
        {
            ListaZaObradu?.ForEach(e=>akcija(e)); 

        }
    }
}
