using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    // Koliko je ukupno elemenata u nizu?
    // Koliko je elemenata niza u mjesecu srpnju?
    // Koliko elemenata niza ima zapis s 7 sekundi?
    // Koja je prosječna vrijednost svih zapisa za minute?
    // U kojim sve godinama postoje zapisi?
    // Koliko je zapisa koji se mogu pojaviti samo u prijestupnim godinama?
    // Koliko je zapisa čije je vrijeme između 4 i 5 sati u noći?
    public class PodaciDateTime
    {

        public static DateTime[] Niz()
        {

            DateTime[] niz = new DateTime[Podaci.Length];
            for (int i = 0; i < Podaci.Length; i++)
            {
                niz[i] = DateTime.Parse(Podaci[i]);
            }
            return niz; 

        }
        private static String[] Podaci = {
        "2024-04-30 03:43:36",
"2024-07-13 05:23:13",
        };


    }
}
