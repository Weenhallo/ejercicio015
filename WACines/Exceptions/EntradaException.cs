using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WACines.Exceptions {
    public class EntradaException : Exception {

        public int Excepcion { get; private set; }

        public EntradaException() {

        }
        public EntradaException(string m, int _excepcion) : base(m) {
            this.Excepcion = _excepcion;
        }
    }
}