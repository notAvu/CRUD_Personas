using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_UWP
{
    public class clsPersona
    {
        #region atributos privados
        private int id;
        private string nombre;
        private string apellido;
        private int idDepartamento;
        private string direccion;
        private string telefono;
        private DateTime fechaNacimiento;
        //foto -> opciones: array de bytes o url (Array de bytes conlleva conversion de tipo de datos)
        private string foto;
        #endregion
        #region constructor
        public clsPersona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public clsPersona(string nombre, string apellido, DateTime fecha, string telefono, string direccion, string foto)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fecha;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
        }
        #endregion
        #region atributos publicos
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Id { get => id; set => id = value; }
        DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        string Telefono { get => telefono; set => telefono = value; }
        string Direccion { get => direccion; set => direccion = value; }
        int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        string Foto { get => foto; set => foto = value; }
        #endregion
    }
}
