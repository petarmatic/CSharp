using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Ocjena:Entitet
    {
        [ForeignKey("ucenik")]
        public Ucenik? Ucenik { get; set; }
        [ForeignKey("predmet")]
        public Predmet? Predmet { get; set; } 
        public string? VrijednostOcjene { get; set; } 
        public DateTime? Datum { get; set; } 
    }
}
