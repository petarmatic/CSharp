namespace Ednevnik.Models
{
    public class Predmet:Entitet
    {
        public string? Naziv { get; set; }

        public ICollection<Obavijest>? Obavijesti { get; set; } = [];
    }
}
