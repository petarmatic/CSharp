using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public record ObavijestDTOInsertUpdate (

        [Required(ErrorMessage = "Tekst obavezno")]
        string? Tekst,

       [Required(ErrorMessage = "Datum obavezno")]
        DateTime? datum,
       [Range(5, 30, ErrorMessage = "{0} mora biti između {1} i {2}")]
       [Required(ErrorMessage = "Predmet obavezno")]
        public int? PredmetId { get; set; }
    );

    
}
