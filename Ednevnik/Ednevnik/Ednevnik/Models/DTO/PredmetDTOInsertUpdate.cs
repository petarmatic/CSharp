using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public record PredmetDTOInsertUpdate
    (
        [Required(ErrorMessage = "Naziv obavezno")]
        string? Naziv

      ); 
    
}
