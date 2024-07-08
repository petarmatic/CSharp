using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E10TryCatch
    {
        public static void Izvedi()
        {

            int broj;


            while (true)
            {
                Console.Write("Upiši broj: ");

                try
                {
                    broj = int.Parse(Console.ReadLine());
                    if (broj <= 0 || broj > 1000)
                    {
                        Console.WriteLine("Broj mora biti između 1 i 1000");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Niste unijeli broj");
                }
            }
            // siguran sam da varijabla broj ima vrijednost
            Console.WriteLine("Hvala na unosu {0} broja", broj);



            string ime;
            do
            {
                Console.Write("Koje je tvoje ime: ");
                ime = Console.ReadLine().Trim();
                if (ime.Length == 0)
                {
                    Console.WriteLine("Niste unijeli ime");
                    continue;
                }
                break;
            } while (true);




            Console.WriteLine("Vaše ime je >{0}<", ime);


        }


    }
}
