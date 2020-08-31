using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Infraestructura {
    public class Pelicula {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Director { get; set; }
        public int Duracion { get; set; }
        public string ElencoPrincipal { get; set; }
        public bool Activa { get; set; }

        public override bool Equals(object obj) {
            return obj is Pelicula pelicula &&
                   Id == pelicula.Id;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }
    }
}
