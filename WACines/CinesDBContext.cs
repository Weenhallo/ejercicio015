using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WACines.Infraestructura;

namespace WACines {
    public class CinesDBContext : DbContext {
        private readonly IConfiguration configuration;

        public CinesDBContext(DbContextOptions<CinesDBContext> options, IConfiguration _configuration) : base(options) {
            this.configuration = _configuration;
        }

        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Sala>().HasData(
                new Sala() { Id = 1, Nombre = "Sala 1", CapacidadMax = 100, Activa = true},
                new Sala() { Id = 2, Nombre = "Sala 2", CapacidadMax = 50, Activa = true },
                new Sala() { Id = 3, Nombre = "Sala 3", CapacidadMax = 20, Activa = true }
            );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
