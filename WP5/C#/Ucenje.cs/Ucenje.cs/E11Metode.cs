using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E11Metode
    {
        public static void Izvedi()
        {
            //Pozivmetode
            Tip1();
            int broj = 5;
            Tip2(broj);
            //Tip2(5);
            Tip2(); // nisam poslao vrijednost pa je uzeta zadana vrijednost 2

            Tip2("Edunova");
            Tip2("Osijek", 7);
            Tip3(); // mnetoda koja vraća vrijednost može biti pozvana kao i void i odraditi će se ali njen rezultat "ode u vjetar"
            Console.WriteLine(Tip3());
            // OVO NE IDE Console.WriteLine(Tip1());

            for (int i = 0; i< 10;i++)
                {
                Console.WriteLine(SlucajnaRijec());
            }


            Console.WriteLine(SumaBrojeva(3,23));
            Console.WriteLine(SumaBrojeva(1,100));

        }

        //kada nije naveden način pristupa je private
        // static je oznaka da se metoda moze a klasi
        // a void je oznaka da metoda ne vraća vrijednost
        //Tip1 je naziv metode, u () su parametri metode
        static void Tip1()
        {
            Console.WriteLine("Sadržaj metode koja ne prima parametar i ne vraća vrijednost");

        }


        public static void Tip2()
        {
            Tip2(2);

        }

        private static void Tip2(int x = 2) //opcionalni parametri, doda se zadana vrijednost=2
        {
            Console.WriteLine("Metoda je primila parametar tipa integer i vrijednošću {0}", x);
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine(i);
            }
        }

        //method overloading
        //metoda može imati isti naziv sve dok prima različite parametre

        private static void Tip2(string ime)
        {
            Console.WriteLine("Preopterećena s stringom vrijednošću:{0}",ime);
        }

        private static void Tip2(string ime, int b)
        {
            Console.WriteLine("Metoda primila {0} i {1}", ime, b);
        }

        //metoda vraća vrijednost

        static int Tip3()
        {
            Console.WriteLine("u metodi Tip3 sam");
            return int.MaxValue; //ili 'a' ili 0
        }

        static int SlucajniBroj()
        {
            return new Random().Next(); 

        }

        static string SlucajnaRijec()
        {
            char [] niz = new char[8];

            var r = new Random();
            for (int i = 0; i<niz.Length;i++)
            {
                niz[i]=(char)r.Next(65,90);

            }

            return string.Join("",niz);

        }

        //trenutno nama najzanimljiviji tip
        // metoda je određenog tipa (vraća vrijednost) i prima parametre

        private static int SumaBrojeva(int min, int max)
        {
            int suma = 0;

            for (int i = min; i<=max;i++)
            {
                suma += i;
            }


            return suma;
        }

    }
    
}
