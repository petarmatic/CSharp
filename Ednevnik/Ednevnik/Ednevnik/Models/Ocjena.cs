using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Ocjena:Entitet
    {
        [ForeignKey("ucenik")]
        public int? UcenikId { get; set; }
        [ForeignKey("predmet")]
        public int? PredmetId { get; set; } 
        public string? VrijednostOcjene { get; set; } 
        public DateTime? Datum { get; set; } 
    }
}
