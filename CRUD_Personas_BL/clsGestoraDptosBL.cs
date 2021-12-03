using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class clsGestoraDptosBL
    {
        clsGestoraDepartamentos gestora;

        public clsGestoraDptosBL()
        {
            gestora = new clsGestoraDepartamentos();
        }
        /// <summary>
        /// Busca en la base de datos el nombre de un departamento segun el id que recibe por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsDepartamento DepartamentoPorId(int id)
        {
            return gestora.leerDepartamentoPorID(id);
        }
        /// <summary>
        /// Llama al metodo homonimo de la DAL para agregar a la bbdd el departamento que se recibe por parametro 
        /// </summary>
        /// <param name="dpto"></param>
        public void AgregarDepartamento(clsDepartamento dpto)
        {
            gestora.AgregarDepartamentoDAL(dpto);
        }
        /// <summary>
        /// Llama al metodo homonimo de la DAL para editar en la bbdd los datos del departamento con el id del que recibe por parameto
        /// </summary>
        /// <param name="dpto"></param>
        public void EditarDepartamento(clsDepartamento dpto)
        {
            gestora.EditarDepartamento(dpto);
        }
        /// <summary>
        /// Elimina el departamento indicado por parametro de la bbdd
        /// </summary>
        /// <param name="dpto"></param>
        public void EliminarDepartamento(clsDepartamento dpto)
        {
            gestora.EliminarDepartamento(dpto.Id);
        }
    }
}
