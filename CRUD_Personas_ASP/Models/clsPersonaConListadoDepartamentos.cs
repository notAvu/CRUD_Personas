using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaConListadoDepartamentos:clsPersona
    {
        #region propiedades privadas 
        private List<clsDepartamento> departamentos;
        #endregion
        #region propiedades publicas
        public List<clsDepartamento> Departamentos { get => departamentos; set => departamentos = value; }
        #endregion
        #region constructores
        public clsPersonaConListadoDepartamentos():base() {
            clsListadoDptosBL listadoDptos;
            listadoDptos = new clsListadoDptosBL();
            Departamentos = listadoDptos.ListadoCompleto();
        }

        public clsPersonaConListadoDepartamentos(int idPersona, string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar) : base(idPersona, nombre, apellido, fecha, telefono, direccion, foto, idDepar)
        {
            clsListadoDptosBL listadoDptos;
            listadoDptos = new clsListadoDptosBL();
            Departamentos = listadoDptos.ListadoCompleto();
        }
        public clsPersonaConListadoDepartamentos(string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar) : base(nombre, apellido, fecha, telefono, direccion, foto, idDepar)
        {
            clsListadoDptosBL listadoDptos;
            listadoDptos = new clsListadoDptosBL();
            Departamentos = listadoDptos.ListadoCompleto();
        }
        #endregion
    }
}
