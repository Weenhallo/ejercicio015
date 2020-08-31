using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WACines.Infraestructura;

namespace WACines.Repository {
    public interface ISalaRepository {
        public Task<Sala> FindById(int id);
        public Task<IEnumerable<Sala>> Find();
        public Task<Sala> Desactivar(int id);
    }
}
