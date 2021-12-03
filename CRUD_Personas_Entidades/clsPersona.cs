using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD_Personas_Entidades
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
        private DateTimeOffset fechaNacimiento;
        private string foto;
        #endregion
        #region constructor
        public clsPersona()
        {
            this.nombre = "";
            this.apellido = "";
            this.fechaNacimiento = new DateTime(1920, 01, 01);
            this.telefono = "";
            this.direccion = "";
            this.foto = "https://www.tenforums.com/geek/gars/images/2/types/thumb_15951118880user.png";
            idDepartamento = 1;
        }
        public clsPersona(string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fecha;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            idDepartamento = idDepar;
        }
        public clsPersona(int idPersona, string nombre, string apellido, DateTimeOffset fecha, string telefono, string direccion, string foto, int idDepar) 
        {
            this.id = idPersona;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fecha;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            idDepartamento = idDepar;
        }
        #endregion
        #region atributos publicos
        [Required (ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellido { get => apellido; set => apellido = value; }
        public int Id { get => id; set => id = value; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTimeOffset FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        [RegularExpression("(6|7)[ -]*([0-9][ -]*){8}", ErrorMessage = "Numero de telefono no valido")]
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public string Foto { get => foto; set => foto = value; }
        #endregion
    }
}
