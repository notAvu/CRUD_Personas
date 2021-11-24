using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CRUD_Personas_BL;
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
    public class PersonasVM : clsVMBase
    {
        #region propiedades privadas
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;
        PersonasBL gestoraPersonas = new PersonasBL();
        DepartamentosBL gestoraDepartamentos = new DepartamentosBL();
        List<clsDepartamento> listadoDepartamentos;
        DelegateCommand comandoAgregar;
        DelegateCommand comandoAlterar;
        DelegateCommand comandoBorrar;
        //Comando editar
        #endregion
        #region constructor
        public PersonasVM()
        {
            try
            {
                listadoPersonas = gestoraPersonas.ListadoCompleto();
                this.listadoDepartamentos = new clsListadoDepartamentos().ListadoCompleto;
            }
            catch
            { }
            personaSeleccionada = listadoPersonas[0];
        }
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); } }
        public clsPersona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                comandoBorrar.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand ComandoAlterar { get { return comandoAlterar = new DelegateCommand(ComandoAlterar_Execute, ComandoAlterar_CanExecute); } }
        public DelegateCommand ComandoBorrar { get { return comandoBorrar = new DelegateCommand(ComandoBorrar_Execute, ComandoBorrar_CanExecute); } }
        public DelegateCommand ComandoAgregar { get { return comandoBorrar = new DelegateCommand(ComandoAgregar_Execute, ComandoAgregar_CanExecute); } }
        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; set => listadoDepartamentos = value; }
        #endregion
        #region commands
        #region comandoAgregar
        private bool ComandoAgregar_CanExecute()
        {
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && personaSeleccionada.FechaNacimiento < DateTime.Today; ;
        }
        private void ComandoAgregar_Execute()
        {
            try
            {
                gestoraPersonas.AgregarPersona(personaSeleccionada);
            }
            catch 
            {
                //message
            }
        }
        #endregion
        #region comandoAlterar
        public void ComandoAlterar_Execute()
        {
            try
            {
                gestoraPersonas.EditarPersona(personaSeleccionada);
            }
            catch
            {
            }
            NotifyPropertyChanged("PersonaSeleccionada");
        }

        public bool ComandoAlterar_CanExecute()
        {
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && personaSeleccionada.FechaNacimiento < DateTime.Today;
        }
        #endregion
        #region comandoBorrar
        public void ComandoBorrar_Execute()
        {
            gestoraPersonas.EliminarPersona(personaSeleccionada);
            ListadoPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListadoPersonas");
        }
        public bool ComandoBorrar_CanExecute()
        {
            return personaSeleccionada != null;
        }
        #endregion
        #endregion
        public clsDepartamento DepartamentoPersonaSeleccionada() 
        {
            return gestoraDepartamentos.DepartamentoPorId(PersonaSeleccionada.IdDepartamento);
        }
    }
}
