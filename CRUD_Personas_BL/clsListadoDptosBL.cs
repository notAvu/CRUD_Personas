using CRUD_Personas_DAL.Listado;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class clsListadoDptosBL
    {
        clsListadoDepartamentos listado;

        public clsListadoDptosBL()
        {
            listado = new clsListadoDepartamentos();
        }
        /// <summary>
        /// Llama al listado de la capa DAL y devuelve su contenido como un List de clsDepartamento
        /// </summary>
        public List<clsDepartamento> ListadoCompleto()
        {
            return listado.ListadoCompleto;
        }
        public List<string> ListadoNombres()
        {
            return listado.ListadoNombres();
        }

    }
}
