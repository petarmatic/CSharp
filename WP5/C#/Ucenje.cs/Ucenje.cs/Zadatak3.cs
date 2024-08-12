using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
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
            //Tip5();
            Tip6();
        }
        private static void Tip6()
        {
            /*
            1. for petlja:  Napravite program koji će na zaslon ispisati prvih 20 prirodnih neparnih brojeva,
                ali u obrnutom redoslijedu(od najvećeg prema najmanjem).Na kraju ispisuje zbroj i umnožak svih tih brojeva
                2.Prepravi 1.program – umjesto for petlje napravi while petlju 
                3.Napiši program: ➢ Do while petlja: sve dok ne učita 
                4 • Ispiše: FORMULE; dva reda prazno; Izaberi broj operacije; 
                novi red; 
                1.c = a + 2 * b; novi red; 
                2.c = b - a; novi red; 
                3.c = 3 * b + 2 * a; novi red
                4. želim van! • Učitati broj •
                Switch case petlja - unutar svakog slučaja :
                ✓ Učitava dva broja a i b tipa double ✓ računa formulu za svaki slučaj(1, 2 i 3) – što se računa možete vidjeti
                u prvom ispisu na početku programa ✓ ispisuje to što je računao ✓ slučaj 
                 4 – izlazi iz switch petlje ✓ U ostalim slučajevima – ispiši  „Krivi si broj upisao. Ajd ispočetka“ 
            */

            int cilj = 20;
            int zbroj = 0;
            int umnozak = 1;

            // int[] brojevi = new int[zbroj];

            for (int i = cilj; i > 0; i--)
            {
                
                    if (i % 2 != 0)
                    {

                        Console.WriteLine(i);
                        zbroj += i;
                        umnozak *= i;
                    }

            }
            Console.WriteLine($"Zbroj: {zbroj}");
            Console.WriteLine($"Umnožak: {umnozak}");
        }

            private static void Tip5()
            {
                int[] niz = { 5, 4, 5, 3, 4, 3 };
                for (int i = 0; i < niz.Length; i++)
                {
                    Console.WriteLine(niz[i]);
                }
            }
            private static void Tip4()
            {
                int i = 0;
                for (; ; )
                {
                    if (i++ > 10)
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
