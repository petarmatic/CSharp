using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E05Z1
    {
        public static void Izvedi()
        {
            // Za unesenu riječ provjerite da li je palindrom?
            // Palindrom je riječ koja se jednako čita s obje strane
            // anavolimilovana, 02022020, ananabraparbanana, evolove, evoove

            string rijec = "evoove";
            bool palidrom= true;

            for (int i = 0; i < rijec.Length / 2; i++)
            {
                if (rijec[i] != rijec[rijec.Length - 1 - i])
                {
                    palidrom = false;
                    break;
                }
    
            }
            /*
            if (palidrom)
            {

                Console.WriteLine("rijec je palidrom");
            }
            else
            {
                Console.WriteLine("rijec nije palidrom");
            }
            */

            Console.WriteLine("Riječ {0} palindrom", palidrom ? "je" : "nije");


        }
    }
}
