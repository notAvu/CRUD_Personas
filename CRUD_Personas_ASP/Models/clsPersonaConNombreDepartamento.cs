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
        public clsPersonaConNombreDepartamento(clsPersona persona)
        {
            DepartamentosBL gestoraDepartamentos;
            gestoraDepartamentos = new DepartamentosBL();
            this.persona = persona;
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(persona.IdDepartamento).Nombre;
        }

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
        public clsPersona Persona { get => persona; set => persona = value; }
    }
}
