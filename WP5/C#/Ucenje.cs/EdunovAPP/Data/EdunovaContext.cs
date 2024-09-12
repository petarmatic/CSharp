using EdunovAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovAPP.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije) : base(opcije)
        {

        }

        public DbSet<Smjer> Smjerovi{ get; set; }

    }
}
