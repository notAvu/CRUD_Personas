using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class clsDepartamento
    {
        string nombre;
        public int Id { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }

        public clsDepartamento(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public clsDepartamento() 
        {
            this.Nombre = "";
        }
    }
}
