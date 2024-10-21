using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Obavijest:Entitet
    {
        public string? Tekst { get; set; } 
        public DateTime? Datum { get; set; }
        [ForeignKey("predmet")]
        public int? PredmetId { get; set; }

        public ICollection<Predmet>? Predmeti { get; set; }

    }
}
