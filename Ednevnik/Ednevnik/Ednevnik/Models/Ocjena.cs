using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Ocjena:Entitet
    {
        [ForeignKey("ucenik_id")]
        public Ucenik? Ucenik { get; set; }
        [ForeignKey("predmet_id")]
        public Predmet? Predmet { get; set; } 
        public string? VrijednostOcjena { get; set; } 
        public DateTime? Datum { get; set; }


        
    }
}
