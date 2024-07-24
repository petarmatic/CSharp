using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs
{
    internal class E03Z4
    {
        internal static void Izvedi()
        {
           /*
        *  KORISTEĆI IF
        * 
       Program učitava od korisnika ime grada.U ovisnosti o imenu grada ispisuje regiju prema sljedećim pravilima:
      Osijek -> Slavonija
      Zadar -> Dalmacija
      Čakovec -> Međimurje
      Pula -> Istra
      Za ostale unose program ispisuje: Ne znam koja je to regija.
       */
 
            // dodatno: Odraditi istu logiku s switch


            Console.Write("Unesi grad: " );
            string grad=Console.ReadLine();

            if (grad == "Osijek")
            {
                Console.WriteLine("Slavonija");
            }
            else if (grad == "Zadar")
            {
                Console.WriteLine("Dalmacija");
            }
            else if (grad == "Čakovec")
            {
                Console.WriteLine("Međimurje");
            }
            else if (grad == "Pula")
            {
                Console.WriteLine("Istra");
            }
            else
            {
                Console.WriteLine("Ne znam koja je to regija");
            }







        }
    }
}
