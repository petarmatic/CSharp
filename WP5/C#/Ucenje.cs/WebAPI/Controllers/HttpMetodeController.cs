using Microsoft.AspNetCore.Mvc;
using WebAPI.NewFolder2;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1[controller]")]
    public class HttpMetodeController : ControllerBase
    {
        //ovdje počinje ruta

        [HttpGet]
        public string Pozdravi()

        {
            return "Hello world";
        }



        //ovdje završava ruta




        //počinje

        [HttpGet]
        [Route("Pozdravi")]
        public string Pozdravi(string ime)
        {

            return "hello " + ime;
        }


        //završava

        //kreiraj rutu naziva zbroj, koja prima 2 cijela broja i vraća nazad njihov zbroj

        [HttpGet]
        [Route("Zbroj")]
        public int Zbroj(int a, int b)
        {
            return a + b;
        }


        //počinje
        [HttpGet]
        [Route("Hello")]
        public IActionResult Pozdravi(int id, string ime)
        {
            return Ok(new { id = id, ime = ime });

        }
        //završava




        //počinje

        [HttpPost]
        public IActionResult Post()
        {
            return BadRequest(new { greska = true, poruka = "Nešto ne valja" });
        }


        //završava


        //počinje

        /*
        [HttpPut]
        public IActionResult Put(Osoba osoba)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { greska = true, pruka = "Nije dobar parametar" });
            }
            osoba.Prezime="g. " + osoba.Prezime;
            return StatusCode(statusCode.status206);

        }
        */

        //završava

        //počinje
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return NotFound(new { id = id, poruka = "Ne mogu pronaći" });
        }
        //završava



    }
}
