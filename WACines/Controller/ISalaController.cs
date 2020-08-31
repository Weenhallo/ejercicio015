using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Controller {
    public interface ISalaController {
        public Task<ActionResult<Sala>> FindById(int id);
        public Task<IEnumerable<Sala>> Find();
        public Task<ActionResult<Sala>> Desactivar(int id);
    }
}
