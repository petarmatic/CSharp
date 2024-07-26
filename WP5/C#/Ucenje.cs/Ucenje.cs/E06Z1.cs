using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E06Z1
    {
        internal static void Izvedi()
        {
            // Korisnik unosi dva broja
            // Program ispisuje sve brojeve između njih

            Console.Write("Unesi prvi broj: ");
            int prvi = int.Parse(Console.ReadLine());
            Console.Write("Unesi drugi broj: ");
            int drugi = int.Parse(Console.ReadLine());

            int brojOd = prvi < drugi ? prvi : drugi;
            int brojDo = prvi > drugi ? prvi : drugi;

            for (int i = brojOd; i <= brojDo; i++) 
                Console.WriteLine(i);
            }



        }
    }

