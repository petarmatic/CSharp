using AutoMapper;
using Ednevnik.Data;
using Ednevnik.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ednevnik.Controllers
{
    public abstract class EdnevnikController:ControllerBase
    {
        protected readonly EdnevnikContext _context;
        protected readonly IMapper _mapper;


        public EdnevnikController(EdnevnikContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
