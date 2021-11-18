using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    class clsDepartamento
    {
        int Id { get; set; }
        string Nombre { get; set; }
        public clsDepartamento(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}
