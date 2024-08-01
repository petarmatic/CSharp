using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class Zadatak1
    {

        public static void Izvedi()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    Console.Write("{0} ", (i + 1) * (j + 1));

                }
                Console.WriteLine();

            }
        }
    }
}
