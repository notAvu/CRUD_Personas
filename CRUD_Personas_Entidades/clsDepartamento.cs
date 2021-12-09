using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class clsDepartamento
    {
        string nombre;
        int id;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public clsDepartamento(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public clsDepartamento() 
        {
            Nombre = "";
            Id = 0;
        }
    }
}
