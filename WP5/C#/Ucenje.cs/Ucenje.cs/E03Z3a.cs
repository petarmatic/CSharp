using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03Z3a
    {
        public static void Izvedi()
        {

            // Program od korisnika traži unos dva cijela broja
            // Program ispisuje manji

            Console.Write("Upiši prvi broj");
            int prvi=int.Parse(Console.ReadLine());
            Console.Write("Upiši drugi broj");
            int drugi=int.Parse(Console.ReadLine());

            if (prvi > drugi)
            {
                Console.WriteLine("prvi je veći, a to je broj{0}", prvi);
            }
            else
            {
                Console.WriteLine("drugi je veći, a to je broj{0}", drugi);
            }




        }

    }
}
