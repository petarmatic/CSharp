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
        public DbSet<Ocjena> Ocjene { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Obavijest>()
                .HasOne(o => o.Predmet)
                .WithMany(p => p.Obavijesti)
                .HasForeignKey(o => o.PredmetId);

            
            modelBuilder.Entity<Ocjena>()
                .HasOne(oc => oc.Ucenik)
                .WithMany(u => u.Ocjene)
                .HasForeignKey(oc => oc.UcenikId);

            
            modelBuilder.Entity<Ocjena>()
                .HasOne(oc => oc.Predmet)
                .WithMany(p => p.Ocjene)
                .HasForeignKey(oc => oc.PredmetId);
        }
    }
}
