using CRUD_Personas_DAL.Listado;
using Entities_UWP;
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
        clsPersona persona = new clsListadoPersonas().leerPersonaPorID(4);
        public MainPageVM() 
        {
            nombrePersona = persona.Nombre;
            apellidoPersona = persona.Apellido;
        }

        public string ApellidoPersona { get => apellidoPersona; set => apellidoPersona = value; }
        public string NombrePersona { get => nombrePersona; set => nombrePersona = value; }
    }
}
