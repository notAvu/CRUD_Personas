using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_DAL.Listado;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class PersonasBL
    {
        clsListadoPersonas listado;
        clsGestoraPersonas gestoraPersonas;

        public PersonasBL()
        {
            listado = new clsListadoPersonas();
            gestoraPersonas = new clsGestoraPersonas();
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
        /// <summary>
        /// LLama al metodo AgregarPersona de la DAL para introducir la persona recibida en la base de datos 
        /// </summary>
        /// <param name="persona"></param>
        public void AgregarPersona(clsPersona persona) 
        {
            gestoraPersonas.AgergarPersonaDAL(persona);
        }

        /// <summary>
        /// LLama al metodo EditarPersona de la DAL para editar los datos de la persona seleccionada en la bbdd 
        /// </summary>
        /// <param name="persona"></param>
        public void EditarPersona(clsPersona persona) 
        {
            gestoraPersonas.EditarPersona(persona);
        }
        /// <summary>
        /// Llama al metodo EliminarPersona de la DAL para borrar la persona con el Id de la persona recibida en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        public void EliminarPersona(clsPersona persona) 
        {
            gestoraPersonas.EliminarPersona(persona.Id);
        }
    }
}
