using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;

namespace WACines.Repository {
    public class SalaRepository : ControllerBase, ISalaRepository {

        private readonly CinesDBContext context;
        private readonly ILogger<SalaRepository> logger;

        public SalaRepository(CinesDBContext _context, ILogger<SalaRepository> _logger) {
            this.context = _context;
            this.logger = _logger;
        }

        public async Task<Sala> Desactivar(int id) {
            logger.LogInformation($"Sala fuera de servicio");
            Sala desactivada = await context.Salas.FindAsync(id);
            desactivada.Activa = false;

            context.Salas.Update(desactivada);
            await context.SaveChangesAsync();

            return desactivada;
        }

        public async Task<IEnumerable<Sala>> Find() {
            logger.LogInformation($"Todas las salas disponibles");

            return await context.Salas.Where(x=> x.Activa).ToListAsync();
        }

        public async Task<Sala> FindById(int id) {
            Sala sala = await context.Salas.Where(x => x.Id == id && x.Activa == true).FirstOrDefaultAsync();

            if (sala == null) {
                logger.LogInformation($"La sala no esta disponible");
                return null;
            }
            else {
                logger.LogInformation($"Informacion de la sala {id}");
                return await context.Salas.FindAsync(id);
            }
        }
    }
}
