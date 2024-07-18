using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcenjeCS;

namespace Ucenje.cs
{
    internal class E13Vjezbanje
    {
        public static void Izvedi()
        {
            //Zadatak1();
            //Zadatak2();
            Zadatak3();


        }

        private static void Zadatak3()
        {
            //Koliko je prim (prosti) (eng. prime) brojeva?


        }

        private bool prim(int broj)
        {
            for (int i = 2; i < broj; i++)
            {
                if(broj%i==0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void Zadatak2()
        {
            var niz=PodaciInt.niz;
            Array.Sort(niz);
            Console.WriteLine(niz[niz.Length-1]);
        }

        private static void Zadatak1()
        {
            // koliko elemenata ima niz int brojeva
            Console.WriteLine(PodaciInt.niz.Length);
            // Postoji li dva ista broja? Ako postoji koji je to broj?
            var niz = PodaciInt.niz;


            
            
            DateTime pocetak = DateTime.Now;
            /*

            for (var i = 0; i < niz.Length; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine(i);
                }
                for (var j = i + 1; j < niz.Length; j++)
                {
                    if (niz[j] == niz[i])
                    {
                        Console.WriteLine(niz[j]);
                        goto labela;
                    }
                }
            }
            labela:
            Console.WriteLine("Trajalo {0}", DateTime.Now - pocetak);
            */

            Array.Sort(niz);
            for (var i = 0; i < niz.Length; i++)
            {
                if (niz[i] == niz[i + 1]) ;
                {
                    Console.WriteLine(niz[i]);
                    break;
                } 
            }
            Console.WriteLine("Trajalo {0}", (DateTime.Now - pocetak).Milliseconds);

        }
    }
}
