using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaSimple
    {
        int id;
        string nombre;
        string apellido;
        string nombreDepartamento;

        public clsPersonaSimple(int id, string nombre,string apellido, string nombreDepartamento )
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.nombreDepartamento = nombreDepartamento;
            this.id = id;
        }

        public clsPersonaSimple()
        {
            apellido = "";
            nombre = "";
            nombreDepartamento = "";
        }

        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
    }
}
