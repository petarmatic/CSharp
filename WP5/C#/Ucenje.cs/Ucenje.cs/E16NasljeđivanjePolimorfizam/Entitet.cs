using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal class Entitet
    {

        public int? Sifra { get; set; }

        public override string ToString()
        {
            return Sifra.ToString();
        }


    }
}
