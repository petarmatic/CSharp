namespace Ednevnik.Models
{
    public class Obavijest:Entitet
    {
        public string? Tekst { get; set; } 
        public DateTime? Datum { get; set; } 
        public int? PredmetId { get; set; }

    }
}
