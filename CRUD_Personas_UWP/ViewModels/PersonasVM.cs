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

        public PersonasVM(List<clsPersona> listadoPersonas)
        {
            this.listadoPersonas = new clsListadoPersonas().ListadoCompleto;
            personaSeleccionada = listadoPersonas[0];
        }
    }
}
