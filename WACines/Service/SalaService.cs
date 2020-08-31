using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Repository;

namespace WACines.Service {
    public class SalaService : ControllerBase, ISalaService {

        private readonly ISalaRepository salaRepository;
        private readonly ILogger<SalaService> logger;

        public SalaService(ISalaRepository _salaRepository, ILogger<SalaService> _logger) {
            this.salaRepository = _salaRepository;
            this.logger = _logger;
        }

        public async Task<Sala> Desactivar(int id) {
            logger.LogInformation($"Sala fuera de servicio");

            return await salaRepository.Desactivar(id);
        }

        public async Task<IEnumerable<Sala>> Find() {
            logger.LogInformation($"Salas disponibles");

            return await salaRepository.Find();
        }

        public async Task<Sala> FindById(int id) {
            logger.LogInformation($"Informacion de la sala {id}");

            return await salaRepository.FindById(id);
        }
    }
}
