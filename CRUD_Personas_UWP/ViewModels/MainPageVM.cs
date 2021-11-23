using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_DAL.Listado;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class MainPageVM
    {
        string nombrePersona;
        string apellidoPersona;
        clsPersona persona = new clsGestoraPersonas().leerPersonaPorID(8);
        public MainPageVM() 
        {
            nombrePersona = persona.Nombre;
            apellidoPersona = persona.Apellido;
        }

        public string ApellidoPersona { get => apellidoPersona; set => apellidoPersona = value; }
        public string NombrePersona { get => nombrePersona; set => nombrePersona = value; }
    }
}
