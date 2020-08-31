using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WACines.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase, IPeliculaController {

        private readonly IPeliculaService peliculaService;
        private readonly ILogger<PeliculaController> logger;

        public PeliculaController(IPeliculaService _peliculaService, ILogger<PeliculaController> _logger) {
            this.peliculaService = _peliculaService;
            this.logger = _logger;
        }

        // POST api/<PeliculaController>
        [HttpPost]
        public async Task<ActionResult<Pelicula>> Create([FromBody] Pelicula pelicula) {
            logger.LogInformation($"Nueva pelicula en cartelera");
            await peliculaService.Create(pelicula);

            return CreatedAtAction("Nueva pelicula", new { id = pelicula.Id }, pelicula);
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> FindById(int id) { 
            var pelicula = await peliculaService.FindById(id);

            if(pelicula == null) {
                logger.LogInformation($"La pelicula no esta disponible");
                return NotFound();
            }
            else {
                logger.LogInformation($"Informacion de la pelicula {id}");
                return pelicula;
            }
        
        }

        // GET: api/<PeliculaController>
        [HttpGet]
        public async Task<IEnumerable<Pelicula>> Find() {
            logger.LogInformation($"Todas las peliculas en cartelera");

            return await peliculaService.Find();
        }    

        // DELETE api/<PeliculaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pelicula>> Desactivar(int id) {
            var pelicula = await peliculaService.FindById(id);

            if (pelicula == null) {
                logger.LogInformation($"La pelicula no esta disponible");
                return NotFound();
            }
            else {
                logger.LogInformation($"Pelicula fuera de cartelera");
                await peliculaService.Desactivar(id);

                return pelicula;
            }
        }
    }
}
