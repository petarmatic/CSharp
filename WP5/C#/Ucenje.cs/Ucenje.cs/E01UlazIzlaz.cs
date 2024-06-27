using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E01UlazIzlaz
    {
        public static void Izvedi()
        {
            Console.WriteLine("Hello");
            Console.Write("Upiši svoje ime: ");

            String ime=Console.ReadLine();
            Console.WriteLine("Unijeli ste: " + ime);
            // formatirani način ispisa
            Console.WriteLine("Unijeli ste {0}", ime);


            // zadatak: Unijeti Adresu i grad te ispisati jedno ispod drugog adresu i grad
            Console.WriteLine("Unesi adresu");
            string adresa = Console.ReadLine();

            Console.WriteLine("Unesi grad");
            string grad = Console.ReadLine();

            Console.WriteLine(adresa);
            Console.WriteLine(grad);


        }





    }
}
