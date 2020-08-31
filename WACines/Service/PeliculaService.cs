using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Repository;

namespace WACines.Service {
    public class PeliculaService : ControllerBase, IPeliculaService {

        private readonly IPeliculaRepository peliculaRepository;
        private readonly ILogger<PeliculaService> logger;

        public PeliculaService(IPeliculaRepository _peliculaRepository, ILogger<PeliculaService> _logger) {
            this.peliculaRepository = _peliculaRepository;
            this.logger = _logger;
        }

        public async Task Create(Pelicula pelicula) {
            logger.LogInformation($"Nueva pelicula en cartelera");
           
            await peliculaRepository.Create(pelicula);

        }

        public async Task<Pelicula> Desactivar(int id) {
            logger.LogInformation($"Pelicula fuera de cartelera");
            
            return await peliculaRepository.Desactivar(id);
        }

        public async Task<IEnumerable<Pelicula>> Find() {
            logger.LogInformation($"Todas las peliculas en cartelera");
            return await peliculaRepository.Find();
        }

        public async Task<Pelicula> FindById(int id) {
            logger.LogInformation($"Informacion de la pelicula {id}");
            return await peliculaRepository.FindById(id);
        }
    }
}
