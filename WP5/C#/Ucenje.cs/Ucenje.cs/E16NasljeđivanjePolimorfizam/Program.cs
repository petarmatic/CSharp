using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal class Program
    {

        // konstruktor - posebna vrsta metode koja se poziva prilikom kreiranje instance klase - objekta
        // ključna riječ new
        // konstruktor se naziva kao i klasa
        public Program()
        {
            Console.WriteLine("Hello from constructor");

            var s = new Smjer();
            s.Sifra = 2;
            s.Naziv = "Wp";

            Console.WriteLine(s.Sifra);
            Console.WriteLine(s.Naziv);

            Console.WriteLine(s.GetHashCode());

            var s1= new Smjer() { Sifra=2, Naziv="Wp"};

            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s.Equals(s1));

            // string je imutable - nepromjenjiv
            var a = "A";
            Console.WriteLine(a.GetHashCode());
            a = a + "B";
            Console.WriteLine(a.GetHashCode());

            StringBuilder sb= new StringBuilder();
            sb.Append('A');
            Console.WriteLine(sb.GetHashCode());
            sb.Append('B');
            Console.WriteLine(sb);

            Console.WriteLine(s.ToString()); // ovako i ne treba
            Console.WriteLine(s); //sada se poziva ToString()


            var g=new Grupa() { Sifra=1,DatumPocetka=DateTime.Now};
            Console.WriteLine(g);

            var polaznik = new Polaznik();
            polaznik.Sifra=1;
            polaznik.Ime = "Pero";

            var predavac=new Predavac() { Sifra=1,Ime="Marko"};

            predavac = new Predavac(2, "Ana", "Mak", "HR2454");

            Console.WriteLine("{0}-{1}",polaznik, predavac);

            //var e = new Entitet(); - apstraktna klasa se ne moze instancirati

            var obradi = new Obrada[2];

            obradi[0] = new ObradaIzlaznihRacuna();
            obradi[1] = new ObradaUlaznihRacuna();

            // polimorfizam
            foreach (var o in obradi)
            {
                o.Procesuiraj();
            }


        }

        // overloads konstruktora
        public Program(string s)
        {
            Console.WriteLine("Hello from constructor " + s);
        }


    }
}
