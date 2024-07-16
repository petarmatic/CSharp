using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E12Rekurzija
    {
        public static void Izvedi()
        {
            //Rekurzija je kada metoda zove samu sebe
            // uz uvijet prekida rekurzije
            //Metoda(); ovo producira StackOVerflow exception
            Console.WriteLine(Zbroji(100));
            int broj = Izracunaj("Koji je broj",2);
        }

        private static int Izracunaj(string tekst, int broj)
        {
            return 0;
        }

        private static void Metoda()
        {

            Metoda();
        }

        private static int Zbroji(int broj)
        {
            if (broj == 1)
            {
                    return 1;
              
            }
            return broj + Zbroji(broj - 1);
        }


    }
}
