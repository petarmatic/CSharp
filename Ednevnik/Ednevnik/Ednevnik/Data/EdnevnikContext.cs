using Microsoft.EntityFrameworkCore;

namespace Ednevnik.Data
{
    public class EdnevnikContext:DbContext
    {
        public EdnevnikContext(DbContextOptions<EdnevnikContext> opcije) :base(opcije) 
        {

        }

    }
    
}
