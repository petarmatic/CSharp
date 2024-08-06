using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class Zadatak3
    {
        internal static void Izvedi()
        {
            // Tip1();
            //Tip2();
            //Tip3();
            //Tip4();
            Tip5();
        }

        private static void Tip5()
        {
            int[] niz = { 5, 4, 5, 3, 4, 3 };
            for(int i = 0; i < niz.Length; i++) 
                {
                    Console.WriteLine(niz[i]);
                }
        }

        private static void Tip4()
        {
            int i = 0;
            for(; ;)
            {
                if(i++>10)
                {
                    break;
                }
                Console.WriteLine("osijek");

            }
        }

        private static void Tip3()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }

        private static void Tip2()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 2)
                    {
                        goto labela;


                    }
                    Console.WriteLine("i={0},j={1}", i, j);
                }
            labela:
                Console.WriteLine("Izlazak iz unutrašnje petlje jer je j dostigao vrijednost 2");
            }

            
        }
      

        private static void Tip1()
        {
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 2)
                    {
                        break;


                    }
                    Console.WriteLine("i={0},j={1}", i, j);
                }
            }
            Console.WriteLine();
        }
    }
}
