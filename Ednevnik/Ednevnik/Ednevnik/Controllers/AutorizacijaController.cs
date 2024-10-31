using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Ednevnik.Data;
using Ednevnik.Models.DTO;

namespace Ednevnik.Controllers
{





    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutorizacijaController(EdnevnikContext context) : ControllerBase
    {
        /// <summary>
        /// Kontekst baze podataka
        /// </summary>
        private readonly EdnevnikContext _context = context;



        /// <summary>
        /// Generira token za autorizaciju.
        /// </summary>
        /// <param name="operater">DTO objekt koji sadrži email i lozinku operatera.</param>
        /// <returns>JWT token ako je autorizacija uspješna, inače vraća status 403.</returns>
        /// <remarks>
        /// Primjer zahtjeva:
        /// <code lang="json">
        /// {
        ///   "email": "mail@mail.hr",
        ///   "password": "lozinka"
        /// }
        /// </code>
        /// </remarks>
        [HttpPost("token")]
        public IActionResult GenerirajToken(OperaterDTO operater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operBaza = _context.Operateri
                   .Where(p => p.Email!.Equals(operater.email))
                   .FirstOrDefault();

            if (operBaza == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, ne mogu naći operatera");
            }

            if (!BCrypt.Net.BCrypt.Verify(operater.password, operBaza.Lozinka))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, lozinka ne odgovara");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MojKljucKojijeJakoTajan i dovoljno dugačak da se može koristiti");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }

}

