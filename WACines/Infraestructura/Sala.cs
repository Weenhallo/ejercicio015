using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WACines.Infraestructura {
    public class Sala {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadMax { get; set; }
        public bool Activa { get; set; }

        [JsonIgnore]
        public IList<Sesion> Sesiones { get; set; }
    }
}
