using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E01Z2
    {
        public static void Izvedi()
        {
            // zadatak
            // Korisnik će unijeti dvoznamenkasti broj
            // Ispisuje se prva znamenka
            // 56 => 5
            // 11 => 1


            Console.Write("unesi dvoznamenkasti broj");
            int broj = int.Parse(Console.ReadLine());

            Console.WriteLine(broj);

            String s=broj.ToString();
            Console.WriteLine(s[0]);


           
        }





    }
}
