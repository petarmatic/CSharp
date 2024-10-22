using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public class OcjenaDTIOInesrtUpdate
    (
        [Required(ErrorMessage = "Tekst obavezno")]
        string? UcenikIme,

        [Required(ErrorMessage = "Predmet obavezno")]
        string? PredmetNaziv,

        [Required(ErrorMessage = "Ocjena obavezno")]
        string? VrijednostOcjene,

        [Required(ErrorMessage = "Datum obavezno")]
        DateTime? Datum


    );
}
