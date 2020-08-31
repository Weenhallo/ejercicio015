using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Exceptions {
    public class PeliculaException : Exception {

        public int Excepcion { get; private set; }

        public PeliculaException() {

        }
        public PeliculaException(string m, int _excepcion) : base(m) {
            this.Excepcion = _excepcion;
        }
    }
}