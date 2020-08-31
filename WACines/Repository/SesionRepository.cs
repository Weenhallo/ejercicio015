using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Infraestructura;

namespace WACines.Repository {
    public class SesionRepository : ControllerBase, ISesionRepository {

        private readonly CinesDBContext context;
        private readonly ILogger<SesionRepository> logger;

        public SesionRepository(CinesDBContext _context, ILogger<SesionRepository> _logger) {
            this.context = _context;
            this.logger = _logger;
        }

        public async Task Create(Sesion sesion) {
            Sesion nuevaSesion = context.Sesiones.Where(x => x.Hora == sesion.Hora && x.SalaId == sesion.Id && x.Activa).FirstOrDefault();
            if (nuevaSesion == sesion) {
                logger.LogInformation($"Ya existe una sesión para esta sala a esa hora");
            }
            DateTime hora = sesion.Hora;
            if (hora < DateTime.Now) {
                logger.LogInformation($"Ya ha pasado la hora");
            }
            logger.LogInformation($"Nueva sesion");
            context.Sesiones.Add(sesion);
            sesion.Activa = true;
            //sesion.EntradasRestantes = context.Salas.FindAsync(sesion.SalaId).Result.CapacidadMax;
            await context.SaveChangesAsync();
        }

        public async Task<Sesion> Desactivar(int id) {
            Sesion sesion = await context.Sesiones.FindAsync(id);

            if (sesion == null) {
                logger.LogInformation($"No se ha podido encontrar la sesion");

                return null;
            }

            logger.LogInformation($"Sesión desactivada");
            sesion.Activa = false;
            context.Sesiones.Update(sesion);
            await context.SaveChangesAsync();
            return sesion;

        }

        public async Task<IEnumerable<Sesion>> Find() {
            logger.LogInformation($"Todas las sesiones disponibles hoy");

            return await context.Sesiones.ToListAsync();

        }

        public async Task<Sesion> FindById(int id) {
            Sesion sesion = await context.Sesiones.Where(x => x.Id == id && x.Activa == true).FirstOrDefaultAsync();

            if (sesion == null) {
                logger.LogInformation($"No se ha encontrado la sesion");

                return null;
            }
            else {
                logger.LogInformation($"Informacion de la sesion {id}");

                return sesion;
            }
        }
    }
}
