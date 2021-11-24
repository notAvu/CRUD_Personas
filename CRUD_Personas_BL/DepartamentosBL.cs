using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_DAL.Listado;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class DepartamentosBL
    {
        clsListadoDepartamentos cls;
        clsGestoraDepartamentos gestora;
        public DepartamentosBL()
        {
            cls = new clsListadoDepartamentos();
        }

        public List<clsDepartamento> ListadoCompleto() 
        {
            return cls.ListadoCompleto;
        }
        public clsDepartamento DepartamentoPorId(int id) 
        {
            return gestora.leerDepartamentoPorID(id);
        }
        public void AgregarDepartamento(clsDepartamento dpto) 
        {
            gestora.AgregarDepartamentoDAL(dpto);
        }
        public void EditarDepartamento(clsDepartamento departamento)
        {
            gestora.EditarDepartamento(departamento);
        }
        public void EliminarDepartamento(clsDepartamento dpto) 
        {
            gestora.EliminarDepartamento(dpto.Id);
        }
    }
}
