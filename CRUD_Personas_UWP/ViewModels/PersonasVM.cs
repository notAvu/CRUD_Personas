using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CRUD_Personas_DAL.Listado;
using Entities_UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM :clsVMBase
    {
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;

        public PersonasVM()
        {
            this.listadoPersonas = new clsListadoPersonas().ListadoCompleto;
            //PersonaSeleccionada = listadoPersonas[0];
        }
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set => listadoPersonas = value; }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }  }
    }
}
