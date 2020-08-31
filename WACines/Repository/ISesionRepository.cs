using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Repository {
    public interface ISesionRepository {
        public Task Create(Sesion sesion);
        public Task<Sesion> FindById(int id);
        public Task<IEnumerable<Sesion>> Find();
        public Task<Sesion> Desactivar(int id);
    }
}
