using System.ComponentModel.DataAnnotations;

namespace Ednevnik.Models
{
    public abstract class Entitet
    {

        [Key] 
        public int? Id { get; set; }
    }
}
