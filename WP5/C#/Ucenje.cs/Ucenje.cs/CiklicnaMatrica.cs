using System;

namespace Ucenje.cs
{
    internal class CiklicnaMatrica
    {
        public static void Izvedi()
        {
            Console.Write("Unesi broj redova: ");
            int redovi = int.Parse(Console.ReadLine());
            Console.Write("Unesi broj stupaca: ");
            int stupci = int.Parse(Console.ReadLine());

            int[,] matrica = Generiraj(redovi, stupci);
            IspisiMatricu(matrica);
        }

        public static int[,] Generiraj(int redovi, int stupci)
        {
            int[,] matrica = new int[redovi, stupci];
            int broj = 1;
            int gornjaGranica = 0, donjaGranica = redovi - 1;
            int lijevaGranica = 0, desnaGranica = stupci - 1;

            while (broj <= redovi * stupci)
            {
                // Popunjavanje donjeg reda s desna na lijevo
                for (int i = desnaGranica; i >= lijevaGranica && broj <= redovi * stupci; i--)
                    matrica[donjaGranica, i] = broj++;
                donjaGranica--;

                // Popunjavanje lijeve kolone odozdo prema gore
                for (int i = donjaGranica; i >= gornjaGranica && broj <= redovi * stupci; i--)
                    matrica[i, lijevaGranica] = broj++;
                lijevaGranica++;

                // Popunjavanje gornjeg reda s lijeve na desno
                for (int i = lijevaGranica; i <= desnaGranica && broj <= redovi * stupci; i++)
                    matrica[gornjaGranica, i] = broj++;
                gornjaGranica++;

                // Popunjavanje desne kolone odozdo prema gore
                for (int i = gornjaGranica; i <= donjaGranica && broj <= redovi * stupci; i++)
                    matrica[i, desnaGranica] = broj++;
                desnaGranica--;
            }

            return matrica;
        }

        public static void IspisiMatricu(int[,] matrica)
        {
            int redovi = matrica.GetLength(0);
            int stupci = matrica.GetLength(1);
            for (int i = 0; i < redovi; i++)
            {
                for (int j = 0; j < stupci; j++)
                {
                    Console.Write(matrica[i, j].ToString("D2") + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
