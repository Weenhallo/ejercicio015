using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Exceptions {
    public class SesionException : Exception {

        public int Excepcion { get; private set; }

        public SesionException() {

        }
        public SesionException(string m, int _excepcion) : base(m) {
            this.Excepcion = _excepcion;
        }
    }
}