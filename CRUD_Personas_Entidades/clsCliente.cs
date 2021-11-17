using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_UWP
{
    public class clsCliente : clsPersona
    {
        #region
        private string telefono;
        private string direccion;

        #endregion

        #region
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        #endregion

        #region
        public clsCliente(string nombre, string apellido, string telefono, string direccion) : base(nombre, apellido)
        {
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion
    }
}
