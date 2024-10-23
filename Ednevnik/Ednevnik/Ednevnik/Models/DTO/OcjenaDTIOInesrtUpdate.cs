using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public class OcjenaDTIOInesrtUpdate
    (
        [Required(ErrorMessage = "Tekst obavezno")]
        string? Ucenik,

        [Required(ErrorMessage = "Predmet obavezno")]
        string? Predmet,

        [Required(ErrorMessage = "Ocjena obavezno")]
        string? VrijednostOcjene,

        [Required(ErrorMessage = "Datum obavezno")]
        DateTime? Datum


    );
}
