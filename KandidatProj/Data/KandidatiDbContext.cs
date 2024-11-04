using KandidatApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandidatApp.Data
{

    public class KandidatiDbContext : DbContext
    {
        public DbSet<Kandidat> Kandidati { get; set; }
        public DbSet<Prilog> Prilozi { get; set; }
        public DbSet<IstorijaPromenaStatusa> StatusIstorija { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KandidatiDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kandidat>()
                .Property(k => k.Status)
                .HasConversion<string>(); // Čuva enum kao string

            modelBuilder.Entity<Kandidat>()
                .HasMany(k => k.Prilozi)
                .WithOne(p => p.Kandidat)
                .HasForeignKey(p => p.KandidatId);

            modelBuilder.Entity<Kandidat>()
                .HasMany(k => k.StatusIstorija)
                .WithOne(s => s.Kandidat)
                .HasForeignKey(s => s.KandidatId);
        }
    }

    
}
