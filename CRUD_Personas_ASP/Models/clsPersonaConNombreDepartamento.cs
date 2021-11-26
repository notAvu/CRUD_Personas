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
        public clsPersonaConNombreDepartamento(int idPersona, string nombre, string apellido, DateTime fecha, string telefono, string direccion, string foto, int idDepar):base(idPersona, nombre, apellido,fecha, telefono, direccion, foto, idDepar)
        {
            DepartamentosBL gestoraDepartamentos;
            gestoraDepartamentos = new DepartamentosBL();
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(this.IdDepartamento).Nombre;
        }
        public clsPersonaConNombreDepartamento(string nombre, string apellido, DateTime fecha, string telefono, string direccion, string foto, int idDepar) : base(nombre, apellido, fecha, telefono, direccion, foto, idDepar)
        {
            DepartamentosBL gestoraDepartamentos;
            gestoraDepartamentos = new DepartamentosBL();
            nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(this.IdDepartamento).Nombre;
        }
        //public clsPersonaConNombreDepartamento(clsPersona per) 
        //{
        //    this.Id = per.Id;
        //    this.Nombre = per.Nombre;
        //    this.Apellido = per.Apellido;
        //    this.FechaNacimiento = per.FechaNacimiento;
        //    this.Telefono = per.Telefono;
        //    this.Direccion = per.Direccion;
        //    this.Foto = per.Foto;
        //    this.IdDepartamento = per.IdDepartamento;
        //    DepartamentosBL gestoraDepartamentos;
        //    gestoraDepartamentos = new DepartamentosBL();
        //    nombreDepartamento = gestoraDepartamentos.DepartamentoPorId(IdDepartamento).Nombre;
        //}

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
