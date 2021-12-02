using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.ViewModels
{
    public class ListadoVM
    {
        clsListadoPersonasBL listadoPersonasBL;
        List<clsPersona> listadoBase;
        List<clsDepartamento> listadoDptos;
        DepartamentosBL gestoraDpto;
        public ListadoVM()
        {
            this.listadoPersonasBL = new clsListadoPersonasBL();
            this.listadoBase = listadoPersonasBL.ListadoCompleto();
            this.gestoraDpto = new DepartamentosBL();
            this.listadoDptos = gestoraDpto.ListadoCompleto();
        }

        public List<clsPersonaSimple> ListadoPersonasConNombreDepartamento() 
        {
            List<clsPersonaSimple> personasDepartamentos;
            personasDepartamentos = (from oPersonaAux in listadoBase
                                     join oDptoAux in listadoDptos on oPersonaAux.IdDepartamento equals oDptoAux.Id
                                     select new clsPersonaSimple()
                                     {
                                         Id = oPersonaAux.Id,
                                         Nombre = oPersonaAux.Nombre,
                                         Apellido = oPersonaAux.Apellido,
                                         NombreDepartamento = oDptoAux.Nombre
                                     }).ToList();
            return personasDepartamentos;
        }
    }
}
