using System.ComponentModel.DataAnnotations.Schema;

namespace Ednevnik.Models.DTO
{
    public record OcjenaDTORead
    (
        int Id,
        string? UcenikIme,
        string? PredmetNaziv,
        string? VrijednostOcjena,
        DateTime? Datum




    );
}
