using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models;
using Ednevnik.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ednevnik.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OcjenaController : EdnevnikController
    {
        public OcjenaController(EdnevnikContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public ActionResult<List<OcjenaDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var ocjene = _context.Ocjene.Include(o => o.Predmet).ToList();
                return Ok(_mapper.Map<List<OcjenaDTORead>>(ocjene));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /*
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OcjenaDTOInsertUpdate> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            Ocjena? ocjena;
            try
            {
                ocjena = _context.Ocjene.Include(o => o.Predmet).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

            if (ocjena == null)
            {
                return NotFound(new { poruka = "Ocjena ne postoji u bazi" });
            }

            return Ok(_mapper.Map<OcjenaDTORead>(ocjena));
        }

        [HttpPost]
        public IActionResult Post(OcjenaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            Predmet? predmet;
            try
            {
                predmet = _context.Predmeti.Find(dto.PredmetId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }

            if (predmet == null)
            {
                return NotFound(new { poruka = "Predmet ne postoji u bazi" });
            }

            try
            {
                var ocjena = _mapper.Map<Ocjena>(dto);
                _context.Ocjene.Add(ocjena);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<OcjenaDTORead>(ocjena));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        } */
    }
}
