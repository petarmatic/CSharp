using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E07Z2
    {
        internal static void Izvedi()
        {
            // Program unosi brojeve sve dok se ne unese broj -1
            // Program ispisuje zbroj svih unesenih brijeva




            int i = 0;
            int suma = 0;

            
            while (true)

            {
                Console.Write("Unesi broj: ");
                i = int.Parse(Console.ReadLine());

                if (i == -1)
                {
                    break;
                }
                suma += i;
            }
            Console.WriteLine("Zbroj svih unesenih brojeva je: " + suma);
            
            /*
            do

            {
                Console.Write("Unesi broj: ");
                i = int.Parse(Console.ReadLine());


                suma += i;
            } while (i > -1);
            Console.WriteLine("Zbroj svih unesenih brojeva je: " + suma);
            */
        }


    }
}


