using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ppedv.Shopchestra.Model;

namespace ppedv.Shopchestra.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Bestellung>? Bestellungen { get; set; }
        public DbSet<BestellPosition>? BestellPositionen { get; set; }
        public DbSet<Kunde>? Kunden { get; set; }
        public DbSet<Musikinstrument>? Musikinstrumente { get; set; }
        public DbSet<Orchester>? Orchester { get; set; }
        public DbSet<Produkt>? Produkte { get; set; }

        private readonly string conString;

        public EfContext(string conString ="Server=(localdb)\\mssqllocaldb;Database=Shopchestra_DEV;Trusted_Connection=true")
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musikinstrument>().ToTable("Instrument");
        }
    }
}