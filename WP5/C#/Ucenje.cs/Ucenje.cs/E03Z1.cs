using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03Z1
    {



        public static void Izvedi()
        {
            // Program od korisnika traži unos broj godina koje ima korisnik
            // Program ispisuje da li je korisnik punoljetna osoba ili ne
            // ako je unos ispod nula godine ili iznad 112 godina ipisasti GREŠKA

            Console.Write("Unesite broj godina: ");

            int godine = int.Parse(Console.ReadLine());

            if (godine < 0 || godine > 112)
            {
                Console.WriteLine("GREŠKA: Unos mora biti između 0 i 112 godina.");
            }
            else
            {
                if (godine >= 18)
                {
                    Console.WriteLine("Punoljetno");
                }
                else
                {
                    Console.WriteLine("Maloljetno");
                }
            }


        }
    }


}

