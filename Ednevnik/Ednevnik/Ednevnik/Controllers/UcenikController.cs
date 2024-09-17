using Ednevnik.Data;
using Ednevnik.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ednevnik.Controllers
{
    [ApiController]
    [Route("api/va/[controller]")]
    public class UcenikController : ControllerBase
    {
        private readonly EdnevnikContext _context;

        public UcenikController(EdnevnikContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Ucenici);

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Ucenici.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Ucenik ucenik)
        {
            _context.Ucenici.Add(ucenik);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, ucenik);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, Ucenik ucenik)
        {
            var ucenikBaza=_context.Ucenici.Find(id);
            ucenikBaza.Ime=ucenik.Ime;
            ucenikBaza.Prezime=ucenik.Prezime;
            ucenikBaza.Oib=ucenik.Oib;
            ucenikBaza.SkolskaGodina=ucenik.SkolskaGodina;

            _context.Ucenici.Update(ucenikBaza);
            _context.SaveChanges();

            return Ok(new {poruka="Uspješno promjenjeno"});



        }
    }



}
