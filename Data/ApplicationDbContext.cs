using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OOAD_G6_najjaci_tim.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OOAD_G6_najjaci_tim.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KorisnikSistema> KorisnikSistema { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<KorisnikSaNalogom> KorisnikSaNalogom { get; set; }
        public DbSet<Gost> Gost { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<SjedisteUTerminu> SjedisteUTerminu { get; set; }
        public DbSet<Karta> Karta { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KorisnikSistema>().ToTable("KorisnikSistema");
            builder.Entity<Administrator>().ToTable("Administrator");
            builder.Entity<KorisnikSaNalogom>().ToTable("KorisnikSaNalogom");
            builder.Entity<Gost>().ToTable("Gost");
            builder.Entity<Racun>().ToTable("Racun");
            builder.Entity<Film>().ToTable("Film");
            builder.Entity<Rezervacija>().ToTable("Rezervacija");
            builder.Entity<Termin>().ToTable("Termin");
            builder.Entity<Sala>().ToTable("Sala");
            builder.Entity<SjedisteUTerminu>().ToTable("SjedisteUTerminu");
            builder.Entity<Karta>().ToTable("Karta").HasOne(e => e.Rezervacija).WithMany().OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
