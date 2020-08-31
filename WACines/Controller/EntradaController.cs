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
    public class EntradaController : ControllerBase, IEntradaController {

        private readonly IEntradaService entradaService;
        private readonly ILogger<EntradaController> logger;

        public EntradaController(IEntradaService _entradaService, ILogger<EntradaController> _logger) {
            this.entradaService = _entradaService;
            this.logger = _logger;
        }

        // POST api/<EntradaController>
        [HttpPost]
        public async Task<ActionResult<Entrada>> Create(Entrada entrada) {
            logger.LogInformation($"Nueva entrada de cine");
            await entradaService.Create(entrada);

            return CreatedAtAction("Nueva entrada", new { id = entrada.Id }, entrada);
        }

        // GET api/<EntradaController>/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Entrada>> FindById(int id) {
            var entrada = await entradaService.FindById(id);

            if(entrada == null) {
                logger.LogInformation($"La entrada no existe");
                return NotFound();
            }
            else {
                logger.LogInformation($"Informacion de la entrada {id}");
                return entrada;
            }
            
            
         }

        // GET: api/<EntradaController>
        [HttpGet]
        public async Task<IEnumerable<Entrada>> Find() {
            logger.LogInformation($"Todas las entradas vendidas");

            return await entradaService.Find();
        }

        // DELETE api/<EntradaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrada>> Devolucion(int id) {
            var entrada = await entradaService.FindById(id);

            if (entrada == null) {
                logger.LogInformation($"La entrada no existe");
                return NotFound();
            }
            else {
                logger.LogInformation($"Entrada devuelta");
                await entradaService.Devolucion(id);

                return entrada;
            }
        }
    }
}

