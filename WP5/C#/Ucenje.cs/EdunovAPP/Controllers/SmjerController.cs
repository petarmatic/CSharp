using EdunovAPP.Data;
using EdunovAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovAPP.Controllers
{
    [ApiController]
    [Route("api/va/[controller]")]
    public class SmjerController : ControllerBase
    {
        // dependency injection
        //1. definirati privatno svojstvo
        private readonly EdunovaContext _context;
        // 2.proslijediš instancu kroz instruktor
        public SmjerController(EdunovaContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Smjerovi);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return Ok(_context.Smjerovi.Find(sifra));
        }


        [HttpPost]
        public IActionResult Post(Smjer smjer)
        {
            _context.Smjerovi.Add(smjer);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, smjer);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, Smjer smjer)
        {
            var smjerBaza = _context.Smjerovi.Find(sifra);
            //za sada ručno kasnije mapper
            smjerBaza.Naziv = smjer.Naziv;
            smjerBaza.Trajanje = smjer.Trajanje;
            smjerBaza.Cijena = smjer.Cijena;
            smjer.IzvodiSeOd = smjer.IzvodiSeOd;
            smjerBaza.Vaucer = smjer.Vaucer;

            _context.Smjerovi.Update(smjerBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno promjenjenoi" });


        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra, Smjer smjer)
        {
            var smjerBaza = _context.Smjerovi.Find(sifra);
            

            _context.Smjerovi.Remove(smjerBaza);
            _context.SaveChanges();

            return Ok(new { poruka = "Uspješno obrisano" });


        }



    }
}
