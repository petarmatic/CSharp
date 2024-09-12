using System.ComponentModel.DataAnnotations;

namespace EdunovAPP.Models
{
    public abstract class Entitet
    {

        [Key] //dio EF ORM-a
        public int? Sifra { get; set; }

    }
}
