using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal abstract class Entitet
    {

        // apstraktna klasa je ona klasa koja se ne može instancirati
        // ona se kreira da bi ju druge klase nasljedile i nadopunile


        public int? Sifra { get; set; }

        public override string ToString()
        {
            return Sifra.ToString();
        }

    }
}