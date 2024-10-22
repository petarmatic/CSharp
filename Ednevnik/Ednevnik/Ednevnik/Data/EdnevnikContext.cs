using Ednevnik.Models;
using Microsoft.EntityFrameworkCore;

namespace Ednevnik.Data
{
    public class EdnevnikContext : DbContext
    {
        public EdnevnikContext(DbContextOptions<EdnevnikContext> opcije) : base(opcije)
        {
        }

        public DbSet<Ucenik> Ucenici { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Obavijest> Obavijesti { get; set; }
        public DbSet<Ocjena> Ocjene {  get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Obavijest>().HasOne<Predmet>(o => o.Predmet);
            modelBuilder.Entity<Ocjena>().HasOne<Ucenik>(oc => oc.Ucenik);
            modelBuilder.Entity<Ocjena>().HasOne<Predmet>(oc => oc.Predmet);

            /*
            modelBuilder.Entity<Obavijest>()
                .HasMany(o => o.Predmeti)
                .WithMany(p => p.Obavijesti)
                .UsingEntity<Dictionary<string, object>>("ObavijestPredmet", 
                    j => j
                        .HasOne<Predmet>()
                        .WithMany()
                        .HasForeignKey("PredmetId"), 
                    j => j
                        .HasOne<Obavijest>()
                        .WithMany()
                        .HasForeignKey("ObavijestId"), 
                    j => j.ToTable("ObavijestPredmet") 
                );
            */
        }
        
    }
}
