using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Controller {
    interface ISesionController {
        public Task<ActionResult<Sesion>> Create(Sesion sesion);
        public Task<ActionResult<Sesion>> FindById(int id);
        public Task<IEnumerable<Sesion>> Find();
        public Task<ActionResult<Sesion>> Desactivar(int id);
    }
}
