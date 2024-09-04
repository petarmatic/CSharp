using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje.cs.E16NasljeđivanjePolimorfizam
{
    internal class ObradaIzlaznihRacuna : Obrada
    {
        public override void Procesuiraj()
        {
            Console.WriteLine("Provjeri bankovni izvod");
            Console.WriteLine("Ažuriraj ako je plaćeno");
        }
    }
}
