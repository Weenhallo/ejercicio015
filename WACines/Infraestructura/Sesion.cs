using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Infraestructura {
    public class Sesion {
        public int Id { get; set; }
        public Sala sala { get; set; }
        public int SalaId { get; set; }
        public Pelicula pelicula { get; set; }
        public int PeliculaId { get; set; }
        public DateTime Hora { get; set; }
        public bool Activa { get; set; }
        public int EntradasRestantes { get; set; }

        public override bool Equals(object obj) {
            return obj is Sesion sesion &&
                   Id == sesion.Id;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }
    }
}