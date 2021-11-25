using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaConNombreDepartamento
    {
        clsPersona persona;
        string nombreDepartamento;
        PersonasBL gestoraPersonas;
        DepartamentosBL gestoraDepartamentos;
        public clsPersonaConNombreDepartamento()
        {
            gestoraPersonas = new PersonasBL();
            gestoraDepartamentos = new DepartamentosBL();
        }
    }
}
