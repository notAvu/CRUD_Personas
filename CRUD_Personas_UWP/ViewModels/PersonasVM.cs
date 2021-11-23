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
        #region propiedades privadas
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;
        clsListadoPersonas listadoDAL=new clsListadoPersonas();
        DelegateCommand comandoAgregar;
        DelegateCommand comandoAlterar;
        DelegateCommand comandoBorrar;
        //Comando editar
        #endregion
        #region constructor
        public PersonasVM()
        {
            this.listadoPersonas =listadoDAL.ListadoCompleto;
            personaSeleccionada = listadoPersonas[0];
        }
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); }  }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                comandoBorrar.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand ComandoAlterar { get { return comandoAlterar=new DelegateCommand(ComandoAlterar_Execute, ComandoAlterar_CanExecute); } }
        public DelegateCommand ComandoBorrar { get { return comandoBorrar = new DelegateCommand(ComandoBorrar_Execute, ComandoBorrar_CanExecute); } }
        public DelegateCommand ComandoAgregar { get { return comandoBorrar = new DelegateCommand(ComandoAgregar_Execute, ComandoAgregar_CanExecute); } }//TODO IMPLEMENTAR COMANDO REAL
        #endregion
        #region commands
        #region
        private bool ComandoAgregar_CanExecute()
        {
            return true;
        }
        private void ComandoAgregar_Execute()
        {
            
        }
        #endregion
        #region comandoAlterar
        public void ComandoAlterar_Execute()
        {
            listadoDAL.EditarPersona(personaSeleccionada);
            NotifyPropertyChanged("PersonaSeleccionada");
        }

        public bool ComandoAlterar_CanExecute()
        {
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && personaSeleccionada.FechaNacimiento<DateTime.Today;
        }
        #endregion
        #region comandoBorrar
        public void ComandoBorrar_Execute() 
        {
            listadoDAL.EliminarPersona(personaSeleccionada.Id);
            ListadoPersonas.Remove(personaSeleccionada);
        }
        public bool ComandoBorrar_CanExecute() 
        {
            return personaSeleccionada!=null;
        }
        #endregion
        #endregion
        public void CrearPersona(string nombre, string apellido, string telefono, string direccion, DateTime fechaNacimiento, string foto, int idDepartamento)
        {
            listadoDAL.AgergarPersonaDAL(personaSeleccionada= new clsPersona(nombre, apellido, fechaNacimiento, telefono, direccion, foto, idDepartamento));
        }
    }
}
