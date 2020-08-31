using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Repository;

namespace WACines.Service {
    public class EntradaService : ControllerBase, IEntradaService {

        private readonly IEntradaRepository entradaRepository;
        private readonly ILogger<EntradaService> logger;

        public EntradaService(IEntradaRepository _entradaRepository, ILogger<EntradaService> _logger) {
            this.entradaRepository = _entradaRepository;
            this.logger = _logger;
        }

        public async Task<ActionResult<Entrada>> Create(Entrada entrada) {
            logger.LogInformation($"Nueva entrada de cine");

            return  await entradaRepository.Create(entrada);
        }

        public async Task<ActionResult<Entrada>> Devolucion(int id) {
            logger.LogInformation($"Entrada devuelta");

            return await entradaRepository.Devolucion(id);
        }

        public async Task<IEnumerable<Entrada>> Find() {
            logger.LogInformation($"Todas las entradas vendidas");
            return await entradaRepository.Find();
        }

        public async Task<Entrada> FindById(int id) {
            logger.LogInformation($"Informacion de la entrada {id}");
            return await entradaRepository.FindById(id);
        }
    }
}
