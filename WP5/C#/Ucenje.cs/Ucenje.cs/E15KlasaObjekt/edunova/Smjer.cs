using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KlasaObjekt.edunova
{
    internal class Smjer
    {
        public int? Sifra { get; set; }
        public string? Naziv { get; set; }
        public decimal? Cijena { get; set; }
        public int? BrojSati { get; set; }
        public DateTime? IzvodiSeOd { get; set; }
        public bool? Vaucer { get; set; }


        // u većini drugih programskih jezika učahuriavnje ide ovako

        private int Broj;

        public void SetBroj(int broj)
        {
            this.Broj = broj; // this označava klasu u kojoj se nalazim
        }

        public int GetBroj()
        {
            return this.Broj;
        }

    }
}