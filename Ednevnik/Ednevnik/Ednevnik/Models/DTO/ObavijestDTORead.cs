namespace Ednevnik.Models.DTO
{
    public record ObavijestDTORead
    (
        int Id,
        string? Tekst, 
        DateTime? Datum, 
        string? PredmetNaziv
    );
}
