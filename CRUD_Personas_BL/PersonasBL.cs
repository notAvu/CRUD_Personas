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
        clsListadoPersonas cls;
        clsGestoraPersonas gestoraPersonas;

        public PersonasBL()
        {
            cls = new clsListadoPersonas();
            gestoraPersonas = new clsGestoraPersonas();
        }

        public List<clsPersona> ListadoCompleto()
        {
            return cls.ListadoCompleto;
        }
        public List<clsPersona> ListadoFiltradoPorDepartamento(int idDepartamento)
        {
            cls.FiltrarPorDepartamento(idDepartamento);
            return cls.ListadoFiltrado;
        }
        public void AgregarPersona(clsPersona persona) 
        {
            gestoraPersonas.AgergarPersonaDAL(persona);
        }
        public void EditarPersona(clsPersona persona) 
        {
            gestoraPersonas.EditarPersona(persona);
        }
        public void EliminarPersona(clsPersona persona) 
        {
            gestoraPersonas.EliminarPersona(persona.Id);
        }
    }
}
