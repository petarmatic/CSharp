using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Obavijest:Entitet
    {
        public string? Tekst { get; set; } 
        public DateTime? Datum { get; set; }
        [ForeignKey("predmet_id")]
        public Predmet? Predmet { get; set; }


    }
}
