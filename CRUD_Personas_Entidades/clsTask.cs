using Entities_UWP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_UWP
{
    public class clsTask
    {
        #region
        clsCliente cliente;
        DateTime fecha;

        #endregion
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public clsCliente Cliente { get => cliente; set => cliente = value; }
        #region

        #endregion
        #region
        public clsTask(clsCliente cliente, DateTime fecha)
        {
            this.cliente = cliente;
            this.fecha = fecha;
        }
        #endregion
    }
}
