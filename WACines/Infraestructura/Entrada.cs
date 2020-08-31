using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Infraestructura {
    public class Entrada {
        public int Id { get; set; }
        public int Precio { get; set; }
        public int EntradasTotales { get; set; }
        public int Descuento { get; set; }
        public Sesion EntradaSesion { get; set; }
        public int SesionId { get; set; }
        public int GananciaTotal { get; set; }

        public override bool Equals(object obj) {
            return obj is Entrada entrada &&
                   Id == entrada.Id;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id);
        }
    }
}
