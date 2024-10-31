namespace Ednevnik.Models
{
    public class Operater:Entitet
    {
        /// <summary>
        /// Operater koji se koristi za prijavu u sustav.
        /// </summary>
       
            /// <summary>
            /// Email operatera.
            /// </summary>
            public string? Email { get; set; }
            /// <summary>
            /// Lozinka operatera.
            /// </summary>
            public string? Lozinka { get; set; }
        }
}
