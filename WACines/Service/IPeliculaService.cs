using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Service {
    public interface IPeliculaService {
        public Task Create(Pelicula pelicula);
        public Task<Pelicula> FindById(int id);
        public Task<IEnumerable<Pelicula>> Find();
        public Task<Pelicula> Desactivar(int id);
    }
}
