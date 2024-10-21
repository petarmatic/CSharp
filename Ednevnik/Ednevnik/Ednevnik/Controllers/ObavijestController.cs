using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models;
using Ednevnik.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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
                return Ok(_mapper.Map<List<ObavijestDTORead>>(_context.Obavijesti.Include(o => o.Predmeti)));
            }
            catch (Exception ex)
            {
                {
                    return BadRequest(new { poruka = ex.Message });
                }

            }
        }
    }

    /*
    [HttpGet]
    [Route("{id:int")]
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


    [HttpGet]
    [Route("Predmeti/{idObavijesti:int}")]
    public ActionResult<List<ObavijestDTORead>> GetPredmeti(int idObavijesti)
    {
        if(!ModelState.IsValid || idObavijesti <= 0)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var p = _context.Obavijesti
                .Include(i => i.Predmeti).FirstOrDefault(x => x.Id == idObavijesti);
            if(p == null)
            {
                return BadRequest("Ne postoji obavijest s id" + idObavijesti);
            }
            return Ok(_mapper.Map<List<PredmetDTORead>>(p.Predmeti));
        }
        catch (Exception ex)
        {
            return BadRequest(new { poruka = ex.Message });
        }
    }
    */
}
