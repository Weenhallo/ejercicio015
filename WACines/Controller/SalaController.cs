using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WACines.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase, ISalaController {

        private readonly ISalaService salaService;
        private readonly ILogger<SalaController> logger;

        public SalaController(ISalaService _salaService, ILogger<SalaController> _logger) {
            this.salaService = _salaService;
            this.logger = _logger;
        }

        // GET api/<SalaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> FindById(int id) {
            Sala sala = await salaService.FindById(id);

            if(sala == null) {
                logger.LogInformation($"La sala no esta disponible");
                return NotFound();
            }

            logger.LogInformation($"Informacion de la sala {id}");
            return sala;
        }

        // GET: api/<SalaController>
        [HttpGet]
        public async Task<IEnumerable<Sala>> Find() {
            logger.LogInformation($"Informacion de las salas disponibles");
            return await salaService.Find();
        }

        // DELETE api/<SalaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sala>> Desactivar(int id) {
            Sala sala = await salaService.FindById(id);

            if (sala == null) {
                logger.LogInformation($"La sala no existe");
                return NotFound();
            }
            else {
                logger.LogInformation($"La sala no esta disponible");
                await salaService.Desactivar(id);

                return sala;
            }
        }
    }
}
