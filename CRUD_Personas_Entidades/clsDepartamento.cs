using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class clsDepartamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
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
