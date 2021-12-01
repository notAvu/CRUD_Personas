using CRUD_Personas_DAL.Listado;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class clsListadoPersonasBL
    {
        clsListadoPersonas listado;
        public clsListadoPersonasBL()
        {
            listado = new clsListadoPersonas();
        }
        /// <summary>
        /// LLama a la DAL para devolver el listado completo de personas contenido en la bbdd
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> ListadoCompleto()
        {
            return listado.ListadoCompleto;
        }
        /// <summary>
        /// Llama a la DAL para devolver un listado de las personas que tienen asignado un departamento especificado por parametro
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public List<clsPersona> ListadoFiltradoPorDepartamento(int idDepartamento)
        {
            listado.FiltrarPorDepartamento(idDepartamento);
            return listado.ListadoFiltrado;
        }
    }
}
