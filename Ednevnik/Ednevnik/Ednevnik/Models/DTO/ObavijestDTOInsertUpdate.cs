using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public record ObavijestDTOInsertUpdate(
        [Required(ErrorMessage = "Tekst obavezno")]
        string? Tekst,

        [Required(ErrorMessage = "Datum obavezno")]
        DateTime? Datum,

        [Range(1, int.MaxValue, ErrorMessage = "{0} mora biti između {1} i {2}")]
        [Required(ErrorMessage = "Predmet obavezno")]
        int? PredmetId 
    );
}
