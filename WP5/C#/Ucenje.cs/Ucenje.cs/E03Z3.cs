using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03Z3

    // Program od korisnika traži unos dva cijela broja
    // Program ispisuje manji
    {


        public static void Izvedi()
        {

            Console.Write("Unesi prvi broj");
            int prvi=int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj");
            int drugi=int.Parse(Console.ReadLine());

            Console.Write("Unesi treći broj");
            int treci = int.Parse(Console.ReadLine());


            int najmanji=(prvi<drugi) ?(prvi<treci ? prvi:treci) :(drugi<treci ? drugi:treci);

            Console.WriteLine("Najmanji broj je: " + najmanji);







        }
    }
}
