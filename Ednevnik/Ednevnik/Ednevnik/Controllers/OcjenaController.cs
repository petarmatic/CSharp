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
    public class OcjenaController(EdnevnikContext context, IMapper mapper) : EdnevnikController(context, mapper)
    {
        

        [HttpGet]
        public ActionResult<List<OcjenaDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                /*
                var ocjene = _context.Ocjene.Include(o => o.Predmet).Include(o => o.Ucenik).ToList();

                
                foreach (var o in ocjene)
                {
                    Console.WriteLine(o.Id);
                } 
                */
                /*
                return Ok(_mapper.Map<List<OcjenaDTORead>>(
                     _context.Ocjene.Include(o => o.Predmet).Include(o => o.Ucenik)
                        ));
                */
                return Ok(_mapper.Map<List<OcjenaDTORead>>(_context.Ocjene.Include(o => o.Predmet).Include(o => o.Ucenik)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
        
        [HttpGet("{id:int}")]
        public ActionResult<OcjenaDTORead> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var ocjena = _context.Ocjene.Include(o => o.Predmet).Include(o => o.Ucenik).FirstOrDefault(o => o.Id == id);

                if (ocjena == null)
                {
                    return NotFound(new { poruka = "Ocjena ne postoji u bazi" });
                }

                return Ok(_mapper.Map<OcjenaDTORead>(ocjena));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post(OcjenaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                
                var predmet = _context.Predmeti.Find(dto.PredmetId);
                var ucenik = _context.Ucenici.Find(dto.UcenikId);

                if (predmet == null)
                {
                    return NotFound(new { poruka = "Predmet ne postoji u bazi" });
                }

                if (ucenik == null)
                {
                    return NotFound(new { poruka = "Učenik ne postoji u bazi" });
                }

                var ocjena = _mapper.Map<Ocjena>(dto);
                _context.Ocjene.Add(ocjena);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, _mapper.Map<OcjenaDTORead>(ocjena));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, OcjenaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var ocjena = _context.Ocjene.Include(o => o.Predmet).Include(o => o.Ucenik).FirstOrDefault(o => o.Id == id);

                if (ocjena == null)
                {
                    return NotFound(new { poruka = "Ocjena ne postoji u bazi" });
                }

                // Provjerite predmet i učenika
                var predmet = _context.Predmeti.Find(dto.PredmetId);
                var ucenik = _context.Ucenici.Find(dto.UcenikId);

                if (predmet == null)
                {
                    return NotFound(new { poruka = "Predmet ne postoji u bazi" });
                }

                if (ucenik == null)
                {
                    return NotFound(new { poruka = "Učenik ne postoji u bazi" });
                }

                ocjena = _mapper.Map(dto, ocjena);
                ocjena.Predmet = predmet;
                ocjena.Ucenik = ucenik;

                _context.Ocjene.Update(ocjena);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var ocjena = _context.Ocjene.Find(id);

                if (ocjena == null)
                {
                    return NotFound(new { poruka = "Ocjena ne postoji u bazi" });
                }

                _context.Ocjene.Remove(ocjena);
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
