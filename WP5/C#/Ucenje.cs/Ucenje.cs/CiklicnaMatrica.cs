using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class CiklicnaMatrica
    {


        public static void Izvedi()
        {
            Console.Write("Unesi broj redova");
            int redovi = int.Parse(Console.ReadLine());
            Console.Write("Unesi broj stupaca");
            int stupci = int.Parse(Console.ReadLine());

            int[,] matrica = Ck(redovi, stupci);

            Ispis(matrica);


        }

        public static int[,] Ck(int redovi, int stupci)
        {
            int[,] matrica = new int[redovi, stupci];


            for (int i = 0; i < redovi; i++)
            {
                matrica[i,0] = i + 1;

            }

            for (int j = 0; j < stupci; j++)
            {

            }


            return matrica;
        }

        public static void Ispis(int[,] matrica)
        {
            int redovi = matrica.GetLength(0);
            int stupci = matrica.GetLength(1);

            for (int i = 0; i < redovi; i++)
            {
                for (int j = 0; j < stupci; j++)
                {
                    Console.Write(matrica[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }


    }



}
