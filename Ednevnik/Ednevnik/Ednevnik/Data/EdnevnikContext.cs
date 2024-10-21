using Ednevnik.Models;
using Microsoft.EntityFrameworkCore;

namespace Ednevnik.Data
{
    public class EdnevnikContext : DbContext
    {
        public EdnevnikContext(DbContextOptions<EdnevnikContext> opcije) : base(opcije)
        {

        }

        public DbSet<Ucenik> Ucenici {  get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Obavijest> Obavijesti { get;set; }

    }
    
}
