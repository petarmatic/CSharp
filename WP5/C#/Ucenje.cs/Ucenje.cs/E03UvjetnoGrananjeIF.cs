using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03UvjetnoGrananjeIF
    {

        public static void Izvedi()
        {

            int i = 7; 

            bool uvjet = i == 8;

            Console.WriteLine(uvjet);


            if (uvjet)
            {
                Console.WriteLine("Vrijednost varijable i je 8");
            }

            // Ovo nikada ne pisati
            if (uvjet == true)
            {

            }

            if (i == 8)
            {

            }

            // if ima i else granu
            if (i > 10)
            {
                Console.WriteLine("i je veći od 10");
            }
            else
            {
                Console.WriteLine("i nije veći od 10");
            }


            // if ne mora imati {} ako se if ili else odnose samo na jednu liniju
            // ovo nije najbolja praksa. Best practice
            if (i > 10)
                Console.WriteLine("i je veći od 10");
            else
                Console.WriteLine("i nije veči od 10");
            Console.WriteLine("AAAAA");



            // puna sintaksa if naredbe
            int b = 2;
            if (b == 1)
            {
                Console.WriteLine("Ne može");
            }
            else if (b > 5)
            {
                Console.WriteLine("OK");
            } // još može ići na else if djelova
            else
            {
                Console.WriteLine("Ostalo");
            }


            // operatori & i &&
            // & uvijek provjerava oba uvjeta
            // && ukoliko 1. uvjet nije zadovoljen, drugi se niti ne gleda
            int x = 2, y = 1;

            if (x == 2 && y == 1)
            {
                Console.WriteLine("x i y su 1");
            }

            // operatori | ||
            // | provjerava oba uvjeta
            // || ukoliko je prvi uvjet zadovoljen, ne gleda se drugi
            if (x > 1 || y == 0)
            {
                Console.WriteLine("ako je prvi uvjet zadovoljen ulazi se u if");
            }


            // if se može gnjezditi
            if (x == 3)
            {
                int k = 9;
                if (i > 0)
                {
                    Console.WriteLine("Zadovoljeno");
                }
            }

            // inline if - tercijarni opetarot ? :
            x = 0;
            if (x == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("NE");
            }

            // preduvjet je da if i else provode istu akciju - u ovom slučaju cw

            Console.WriteLine(x == 0 ? "OK" : "NE");




        }




    }
}
