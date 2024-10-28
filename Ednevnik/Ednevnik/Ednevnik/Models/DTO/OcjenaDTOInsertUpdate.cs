using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models.DTO
{
    public class OcjenaDTOInsertUpdate
    {
        [Required(ErrorMessage = "Učenik obavezan")]
        public int UcenikId { get; set; }

        [Required(ErrorMessage = "Predmet obavezan")]
        public int PredmetId { get; set; }

        [Required(ErrorMessage = "Ocjena obavezna")]
        public string VrijednostOcjena { get; set; }

        [Required(ErrorMessage = "Datum obavezan")]
        public DateTime Datum { get; set; }
    }

}
