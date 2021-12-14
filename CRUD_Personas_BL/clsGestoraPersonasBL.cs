using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class clsGestoraPersonasBL
    {
        clsGestoraPersonas gestoraPersonas;

        public clsGestoraPersonasBL()
        {
            this.gestoraPersonas = new clsGestoraPersonas();
        }
        /// <summary>
        /// Llama al metodo leerPersona de DAL para devolver un objeto persona con los datos de aquella con el dni indicado en la bbdd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona LeerPpersonaPorId(int id)
        {
            return gestoraPersonas.leerPersonaPorID(id);
        }
        ///
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
        public void EliminarPersona(int Idpersona)
        {
            gestoraPersonas.EliminarPersona(Idpersona);
        }
    }
}
