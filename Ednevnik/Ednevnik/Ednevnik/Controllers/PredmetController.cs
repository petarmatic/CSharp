using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models;
using Ednevnik.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ednevnik.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PredmetController : EdnevnikController
    {
        public PredmetController(EdnevnikContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /*
        [HttpGet]
        public ActionResult<List<PredmetDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<PredmetDTORead>>(_context.Predmeti));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
        */

        [HttpGet]
        public ActionResult<List<PredmetDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var predmeti = _context.Predmeti.ToList(); 
                return Ok(_mapper.Map<List<PredmetDTORead>>(predmeti));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }



        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<PredmetDTORead> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Predmet? e;
            try
            {
                e = _context.Predmeti.Find(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Predmet ne postoji u bazi" });
            }
            return Ok(_mapper.Map<PredmetDTORead>(e));
        }

        [HttpPost]
        public IActionResult Post(PredmetDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var predmet = _mapper.Map<Predmet>(dto);
                _context.Predmeti.Add(predmet); 
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<PredmetDTORead>(predmet)); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpPut("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, PredmetDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var predmet = _context.Predmeti.Find(id);
                if (predmet == null)
                {
                    return NotFound(new { poruka = "Predmet ne postoji u bazi" });
                }
                _mapper.Map(dto, predmet);
                _context.Predmeti.Update(predmet);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno promijenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var predmet = _context.Predmeti.Find(id);
                if (predmet == null)
                {
                    return NotFound(new { poruka = "Predmet ne postoji u bazi" });
                }
                _context.Predmeti.Remove(predmet);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}
