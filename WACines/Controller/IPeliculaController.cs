using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Controller {
    public interface IPeliculaController {
        public Task<ActionResult<Pelicula>> Create(Pelicula pelicula);
        public Task<ActionResult<Pelicula>> FindById(int id);
        public Task<IEnumerable<Pelicula>> Find();
        public Task<ActionResult<Pelicula>> Desactivar(int id);
    }
}
