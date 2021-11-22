using CRUD_Personas_DAL.Listado;
using Entities_UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM
    {
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;

        public PersonasVM()
        {
            this.listadoPersonas = new clsListadoPersonas().ListadoCompleto;
        }
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set => listadoPersonas = value; }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set => personaSeleccionada = value; }
    }
}
