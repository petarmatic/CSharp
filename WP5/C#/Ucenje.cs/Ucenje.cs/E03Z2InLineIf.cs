using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03Z2InLineIf
    {


        public static void Izvedi()
        {

            Console.Write("Unesi cijeli broj");
            int broj=int.Parse(Console.ReadLine());

           Console.WriteLine(broj % 2 == 0 ? "Broj je paran" : "broj je neparan");


        }
        }
}
