using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E06ForPetlja
    {


        public static void Izvedi()
        {



            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");

            Console.WriteLine("****************************");

            for (int i = 0; i < 10; i = i + 1) // i++ ++i i+=1
            {
                Console.WriteLine("Osijek");
            }

            Console.WriteLine("****************************");


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1);
            }



            Console.WriteLine("****************************");

            // korištenje vrijednosti u petlji

            int suma = 0;
            for (int i = 1; i <= 100; i++)
            {
                suma += i;
            }
            Console.WriteLine(suma);


            // ispiši sve parne brojeve od 1 do 50
            // loš način
            for (int i = 2; i <= 50; i += 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("****************************");

            // dobar način
            for (int i = 1; i <= 50; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }


            Console.WriteLine("****************************");


            int brojOd = 120;
            int brojDo = 20;


            for (int i = brojOd; i > brojDo; i--)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("****************************");

            int[] niz = { 2, 3, 2, 3, 4, 5, 4, 3 };

            // ispisati sve parne vrijednosti niza
            for (int i = 0; i < niz.Length; i++)
            {
                if (niz[i] % 2 == 0)
                {
                    Console.WriteLine(niz[i]);
                }
            }

            Console.WriteLine("****************************");

            int[,] tablica = {
            {1,2,30 }, // DZ 6 i 9 moraju biti ispod 0 od 30
            {4,5,6 },
            {7,8,9 }
            };


            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {
                    Console.Write(tablica[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("****************************");


            // tablica množenja - DZ lijepo formatirati
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write((i + 1) * (j + 1) + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("****************************");
            // petlja se može preskočiti (nastaviti) i nasilno prekinuti
            int ukupno = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i == 1 || i == 3)
                {
                    continue;
                }

                if (++ukupno > 5)
                {
                    break;
                }



                Console.WriteLine(i);


            }


            Console.WriteLine("****************************");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // kako iz unutarnje prekinuti fanjsku petlju - pomoću labela
                    goto labela;
                    //break;
                }
                // ovdje me bacio break iz unutarnje petlje
            }

        labela:
            Console.WriteLine("Hello");


            Console.WriteLine("****************************");




            // beskonačna petlja
            // loša - NE VALJA, ne koristiti
            for (int i = 0; i > -1; i++)
            {
                break;
            }

            int broj = 0;
            // ispravna beskonačna petlja
            for (; ; )
            {
                Console.Write("Unesi broj između 10 i 20: ");
                broj = int.Parse(Console.ReadLine());
                if (broj >= 10 && broj <= 20)
                {
                    break;
                }
                Console.WriteLine("Neispravan unos");
            }

            Console.WriteLine("Unijeli ste " + broj);

            Console.WriteLine("****************************");


            // nizovi + petlje

            // string tip podatke je zapravo niz znakova

            string ime1 = "Ana";
            char[] ime2 = { 'A', 'n', 'a', };


            for (int i = 0; i < ime2.Length; i++)
            {
                Console.Write(ime2[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < ime1.Length; i++)
            {
                Console.Write(ime1[i]);
            }

        }
    }
}
