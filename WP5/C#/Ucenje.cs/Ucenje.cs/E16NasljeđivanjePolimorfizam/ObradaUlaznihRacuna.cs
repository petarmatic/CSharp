using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal class ObradaUlaznihRacuna : Obrada
    {
        public override void Procesuiraj()
        {
            Console.WriteLine("Plati preko banke");
        }
    }
}
