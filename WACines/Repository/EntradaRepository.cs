using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WACines.Exceptions;
using WACines.Infraestructura;

namespace WACines.Repository {
    public class EntradaRepository : ControllerBase, IEntradaRepository {

        private readonly CinesDBContext context;
        private readonly ILogger<EntradaRepository> logger;

        public EntradaRepository(CinesDBContext _context, ILogger<EntradaRepository> _logger) {
            this.context = _context;
            this.logger = _logger;
        }

        private int PrecioTotalCompra(Entrada entrada) {
            int total = entrada.EntradasTotales * entrada.Precio;
            if (entrada.EntradasTotales >= 5) {
                total = (int)(total * 0.9);
            }
            return total;
        }

        public async Task<ActionResult<Entrada>> Create(Entrada entrada) {
            logger.LogInformation($"Nueva entrada de cine");
            var entradaSesion = await context.Sesiones.Where(x => x.Id == entrada.SesionId).FirstOrDefaultAsync();

            if (entradaSesion == null) {
                throw new EntradaException("La entrada no existe", 1);
            }
            if (entradaSesion.Activa == false) {
                throw new EntradaException("La sesion no esta disponible para comprar entradas", 2);

            }
            if (entradaSesion.EntradasRestantes < entrada.EntradasTotales) {
                throw new EntradaException("No quedan entradas disponibles", 3);
            }

            entrada.GananciaTotal += PrecioTotalCompra(entrada);
            context.Entradas.Add(entrada);
            entradaSesion.EntradasRestantes -= entrada.EntradasTotales;

            await context.SaveChangesAsync();

            return entrada;
        }

        public async Task<ActionResult<Entrada>> Devolucion(int id) {
            logger.LogInformation($"Devolucion de la entrada de cine");
            Entrada entradaADevolver = await context.Entradas.FindAsync(id);
            Sesion sesion = await context.Sesiones.Where(x => x.Activa).SingleOrDefaultAsync(s => s.Id == entradaADevolver.SesionId);

            if (entradaADevolver == null) {
                throw new EntradaException("La entrada no existe", 1);
            }

            sesion.EntradasRestantes += entradaADevolver.EntradasTotales;
            context.Entradas.Update(entradaADevolver);
            entradaADevolver.GananciaTotal -= PrecioTotalCompra(entradaADevolver);
            await context.SaveChangesAsync();

            return entradaADevolver;
        }

        public async Task<IEnumerable<Entrada>> Find() {
            logger.LogInformation($"Todas las entradas vendidas");

            return await context.Entradas.ToListAsync();
        }

        public async Task<Entrada> FindById(int id) {
            Entrada entrada = await context.Entradas.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entrada == null) {
                throw new EntradaException("La entrada no existe", 1);
            }
            else {
                logger.LogInformation($"Informacion de la entrada {id}");
                return await context.Entradas.FindAsync(id);
            }
        }
    }
}
