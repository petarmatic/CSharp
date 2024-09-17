namespace Ednevnik.Models
{
    public class Ocjena:Entitet
    {
        public int? UcenikId { get; set; } 
        public int? PredmetId { get; set; } 
        public string? VrijednostOcjene { get; set; } 
        public DateTime? Datum { get; set; } 
    }
}
