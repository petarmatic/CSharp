using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KlasaObjekt.edunova
{
    internal class Grupa
    {
        public int? Sifra { get; set; }
        public string? Naziv { get; set; }
        public int? BrojSlobodnihMjesta { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public Smjer? Smjer { get; set; }
        public string? Predavac { get; set; }
        public Polaznik[]? Polaznici { get; set; }
    }
}