using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E04Z1
    {



        // Korisnik unosi brojčanu vrijednost ocjene od 1 do 5
        // Program ispisuje slovno ocjenu, a ako korsnik nije unosio ocjenu
        // program ispisuje: broj nije ocjena

        public static void Izvedi()
        {
            Console.Write("Unesi ocjenu od 1 do 5: ");
            int ocjena=int.Parse(Console.ReadLine());

            switch (ocjena)
            {
                case 1:
                    Console.WriteLine("jedan");
                    break;
                case 2:
                    Console.WriteLine("dva");
                    break;
                case 3:
                    Console.WriteLine("tri");
                    break;
                case 4:
                    Console.WriteLine("četiri");
                    break;
                case 5:
                    Console.WriteLine("pet");
                    break;
                default:
                    Console.WriteLine("Broj nije ocjena");
                    break;

            }

        }


        }
}
