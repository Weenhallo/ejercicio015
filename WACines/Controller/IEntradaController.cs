using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Controller {
    public interface IEntradaController {

        public Task<ActionResult<Entrada>> Create (Entrada entrada);
        public Task<ActionResult<Entrada>> FindById(int id);
        public Task<IEnumerable<Entrada>> Find();
        public Task<ActionResult<Entrada>> Devolucion(int id);
    }
}
