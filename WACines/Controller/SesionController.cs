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
    public class SesionController : ControllerBase, ISesionController {

        private readonly ISesionService sesionService;
        private readonly ILogger<SesionService> logger;

        public SesionController(ISesionService _sesionService, ILogger<SesionService> _logger) {
            this.sesionService = _sesionService;
            this.logger = _logger;
        }

        // POST api/<SesionController>
        [HttpPost]
        public async Task<ActionResult<Sesion>> Create([FromBody]Sesion sesion){
            logger.LogInformation($"Nueva sesion");
            await sesionService.Create(sesion);

            return CreatedAtAction("Sesion creada", new { id = sesion.Id }, sesion);
        }

        // GET api/<SesionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> FindById(int id) {
            var sesion = await sesionService.FindById(id);

            if (sesion == null) {
                logger.LogInformation($"No se ha encontrado la sesion");

                return NotFound();
            }
            else {
                logger.LogInformation($"Informacion de la sesion {id}");

                return sesion;
            }
        }

        // GET: api/<SesionController>
        [HttpGet]
        public async Task<IEnumerable<Sesion>> Find() {
            logger.LogInformation($"Todas las sesiones disponibles hoy");

            return await sesionService.Find();
        }

        // DELETE api/<SesionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sesion>> Desactivar(int id) {
             var sesion = await sesionService.FindById(id);

             if (sesion == null) {
                logger.LogInformation($"No se ha podido encontrar la sesion");

                return NotFound();
             }
             else {
                logger.LogInformation($"Sesion terminada");

                return await sesionService.Desactivar(id);
             }
            }
    }
}
