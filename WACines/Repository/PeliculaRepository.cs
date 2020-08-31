using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;

namespace WACines.Repository {
    public class PeliculaRepository : ControllerBase, IPeliculaRepository {

        private readonly CinesDBContext context;
        private readonly ILogger<PeliculaRepository> logger;

        public PeliculaRepository(CinesDBContext _context, ILogger<PeliculaRepository> _logger) {
            this.context = _context;
            this.logger = _logger;
        }

        public async Task Create(Pelicula pelicula) {
            logger.LogInformation($"Nueva pelicula en cartelera");
            context.Peliculas.Add(pelicula);
            pelicula.Activa = true;
            await context.SaveChangesAsync();
        }

        public async Task<Pelicula> Desactivar(int id) {
            logger.LogInformation($"Pelicula fuera de cartelera");
            Pelicula deBaja = await context.Peliculas.FindAsync(id);
            deBaja.Activa = false;

            context.Peliculas.Update(deBaja);
            await context.SaveChangesAsync();

            return deBaja;
        }

        public async Task<IEnumerable<Pelicula>> Find() {
            logger.LogInformation($"Todas las peliculas en cartelera");

            return await context.Peliculas.Where(x => x.Activa).ToListAsync();
        }

        public async Task<Pelicula> FindById(int id) {
            Pelicula pelicula = await context.Peliculas.Where(x => x.Id == id && x.Activa == true).FirstOrDefaultAsync();

            if (pelicula == null) {
                logger.LogInformation($"La pelicula no esta disponible");
                return null;
            }
            else {
                logger.LogInformation($"Informacion de la pelicula {id}");
                return await context.Peliculas.FindAsync(id);
            }
        }
    }
}
