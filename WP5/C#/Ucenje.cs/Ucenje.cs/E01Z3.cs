using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E01Z3
    {
        public static void Izvedi()
        {

            //Program od korisnika učitava ime grada i broj stanovnika.
            //Ispisuje rečenicu: U XXXXXXX živi XXXXX ljudi.

            // Osigurati da se upiše grad
            // Osigurati da se upiše broj stanovnika kao broj

            Console.Write("upiši grad");
            var grad=Console.ReadLine();



            Console.Write("upiši broj stanovnika");
            int broj = int.Parse(Console.ReadLine());

            Console.WriteLine("u {0} živi {1} stanovnika",grad, broj);




        }


    }
}
