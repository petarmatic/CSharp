using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models;
using Ednevnik.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Ednevnik.Controllers
{



    [ApiController]
    [Route("api/v1/[controller]")]
    public class ObavijestController(EdnevnikContext context, IMapper mapper) : EdnevnikController(context, mapper)
    {
        [HttpGet]
        public ActionResult<List<ObavijestDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {

                List<Obavijest> lista = _context.Obavijesti.Include(o => o.Predmet).ToList();
                foreach(var o in lista)
                {
                    Console.WriteLine(o.Id);
                }
                return Ok(_mapper.Map<List<ObavijestDTORead>>(lista));
            }
            catch (Exception ex)
            {

                return BadRequest(new { poruka = ex.Message });


            }
        }



        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ObavijestDTOInsertUpdate> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Obavijest? e;
            try
            {
                e = _context.Obavijesti.Include(o => o.Predmet).FirstOrDefault(o => o.Id == id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Obavijest ne postoji u bazi" });
            }
            return Ok(_mapper.Map<ObavijestDTOInsertUpdate>(e));
        }

        [HttpPost]
        public IActionResult Post(ObavijestDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Predmet? p;
            try
            {
                p = _context.Predmeti.Find(dto.PredmetId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (p == null)
                return NotFound(new { poruka = "Predmet na obavijesti ne postoji u bazi" });


            try
            {
                var e = _mapper.Map<Obavijest>(dto);
                e.Predmet = p;
                _context.Obavijesti.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<ObavijestDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Put(int id, ObavijestDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Obavijest? e;
                try
                {
                    e = _context.Obavijesti.Include(o => o.Predmet).FirstOrDefault(x => x.Id == id);
                }

                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Obavijest ne postoji u bazi" });
                }

                Predmet p;
                try
                {
                    p = _context.Predmeti.Find(dto.PredmetId);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (p == null)
                {
                    return NotFound(new { poruka = "Predmet na obavijesti ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);
                e.Predmet = p;
                _context.Obavijesti.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }


        }


        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Obavijest? o;
                try
                {
                    o = _context.Obavijesti.Find(id);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (o == null)
                {
                    return NotFound("Obavijest ne postoji u bazi");
                }
                _context.Obavijesti.Remove(o);
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