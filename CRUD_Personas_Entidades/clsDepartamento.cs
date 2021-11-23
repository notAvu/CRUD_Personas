using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class clsDepartamento
    {
        int Id { get; set; }
        string Nombre { get; set; }
        public clsDepartamento(string nombre, int id)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
