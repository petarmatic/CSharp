using Ednevnik.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ednevnik.Controllers
{
    public class UcenikController:ControllerBase
    {
        private readonly EdnevnikContext _context;

        public UcenikController(EdnevnikContext context)
        {
            _context = context;
        }

    }
}
