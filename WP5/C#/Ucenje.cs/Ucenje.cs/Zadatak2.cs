using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class Zadatak2
    {
        public static void Izvedi()
        {
            string s;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var b = (i + 1) * (j + 1);
                    s = b.ToString();
                    Console.Write("{0,4}", b);

                }
                Console.WriteLine();


            }
        }

    }
}
