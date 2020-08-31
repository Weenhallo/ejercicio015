using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;
using WACines.Repository;

namespace WACines.Service {
    public class SesionService : ControllerBase, ISesionService {

        private readonly ISesionRepository sesionRepository;
        private readonly ILogger<SesionRepository> logger;

        public SesionService(ISesionRepository _sesionRepository, ILogger<SesionRepository> _logger) {
            this.sesionRepository = _sesionRepository;
            this.logger = _logger;
        }

        public async Task Create(Sesion sesion) {
            logger.LogInformation($"Nueva sesion");

            await sesionRepository.Create(sesion);

        }

        public async Task<Sesion> Desactivar(int id) {
            logger.LogInformation($"Sesion terminada");

            return await sesionRepository.Desactivar(id);
        }

        public async Task<IEnumerable<Sesion>> Find() {
            logger.LogInformation($"Todas las sesiones disponibles hoy");

            return await sesionRepository.Find();
        }

        public async Task<Sesion> FindById(int id) {
            logger.LogInformation($"Informacion de la sesion {id}");

            return await sesionRepository.FindById(id);
        }
    }
}
