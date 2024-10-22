using AutoMapper;
using Ednevnik.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ednevnik.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OcjenaController(EdnevnikContext context, IMapper mapper): EdnevnikController(context, mapper)
    {




    }
}
