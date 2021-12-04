using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaConNombreDepartamento:clsPersona
    {
        string nombreDepartamento;
        public clsPersonaConNombreDepartamento(int idPersona, string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar):base(idPersona, nombre, apellido,fecha, telefono, direccion, foto, idDepar)
        {
            clsGestoraDptosBL gestoraDepartamentos;
            gestoraDepartamentos = new clsGestoraDptosBL();
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(this.IdDepartamento).Nombre;
        }
        public clsPersonaConNombreDepartamento(string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar) : base(nombre, apellido, fecha, telefono, direccion, foto, idDepar)
        {
            clsGestoraDptosBL gestoraDepartamentos;
            gestoraDepartamentos = new clsGestoraDptosBL();
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(this.IdDepartamento).Nombre;
        }
        public clsPersonaConNombreDepartamento(int id, string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar, string nombreDpto) : base(id, nombre, apellido, fecha, telefono, direccion, foto, idDepar)
        {
            clsGestoraDptosBL gestoraDepartamentos;
            gestoraDepartamentos = new clsGestoraDptosBL();
            nombreDepartamento = nombreDpto;
        }
        public clsPersonaConNombreDepartamento(clsPersona persona)
        {
            Id = persona.Id;
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            FechaNacimiento = persona.FechaNacimiento;
            Telefono = persona.Telefono;
            Direccion = persona.Direccion;
            Foto = persona.Foto;
            IdDepartamento = persona.IdDepartamento;
            clsGestoraDptosBL gestoraDepartamentos;
            gestoraDepartamentos = new clsGestoraDptosBL();
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(this.IdDepartamento).Nombre;
        }
        public clsPersonaConNombreDepartamento():base()
        {
            nombreDepartamento = "";
        }

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
