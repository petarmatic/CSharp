using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models
{
    public class Ucenik:Entitet
    {
        
        public string? Ime { get; set; } 
        public string? Prezime { get; set; } 
        public string? Oib { get; set; }
        [Column("skolska_godina")]
        public string? SkolskaGodina { get; set; } 
    }
}
