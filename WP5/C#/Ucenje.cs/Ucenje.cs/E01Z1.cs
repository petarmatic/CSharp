using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E01Z1
    {
        public static void Izvedi()
        {

            // zadatak
            // Korisnik unosi dva cijela broja i ispisuje njihov zbroj

            Console.Write("Unesi prvi broj");
            int prvi=int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj" );
            int drugi=int.Parse(Console.ReadLine());


            int rezultat = prvi + drugi;
            Console.WriteLine("Rezultat je: " + rezultat);

            Console.WriteLine("Rezultat je: " + prvi + drugi);



        }
    }
}
