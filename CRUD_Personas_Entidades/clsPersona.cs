using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_UWP
{
    public class clsPersona
    {
        #region atributos privados
        private string nombre;
        private string apellido;
        #endregion
        #region constructor
        public clsPersona(string nombre,string apellido)
        {
            this.nombre=nombre;
            this.apellido = apellido;
        }
        #endregion
        #region atributos publicos
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        #endregion
    }
}
