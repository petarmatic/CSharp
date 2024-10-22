using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ednevnik.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OcjenaController(EdnevnikContext context, IMapper mapper): EdnevnikController(context, mapper)
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
                return Ok(_mapper.Map<List<OcjenaDTORead>>(_context.Ocjene.Include(o => o.Predmet)));
            }
            catch (Exception ex)
            {

                return BadRequest(new { poruka = ex.Message });


            }
        }



    }
}
