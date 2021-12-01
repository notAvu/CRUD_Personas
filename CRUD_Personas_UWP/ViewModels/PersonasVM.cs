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
using Windows.UI.Popups;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM : clsVMBase
    {
        #region propiedades privadas
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;
        clsGestoraPersonasBL gestoraBL;
        clsListadoPersonasBL listadoBL;
        DepartamentosBL gestoraDepartamentos = new DepartamentosBL();
        List<clsDepartamento> listadoDepartamentos;
        DelegateCommand comandoAgregar;
        DelegateCommand comandoAlterar;
        DelegateCommand comandoBorrar;
        #endregion
        #region constructor
        public PersonasVM()
        {
            try
            {
                listadoPersonas = listadoBL.ListadoCompleto();
                this.listadoDepartamentos = new clsListadoDepartamentos().ListadoCompleto;
                personaSeleccionada = listadoPersonas[0];
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
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
            }
        }
        /// <summary>
        /// Comando para editar los datos de una persona en la base de datos 
        /// </summary>
        public DelegateCommand ComandoAlterar { get { return comandoAlterar = new DelegateCommand(ComandoAlterar_Execute, ComandoAlterar_CanExecute); } }
        /// <summary>
        /// Comando para eliminar a una persona de la base de datos 
        /// </summary>
        public DelegateCommand ComandoBorrar { get { return comandoBorrar = new DelegateCommand(ComandoBorrar_Execute, ComandoBorrar_CanExecute); } }
        /// <summary>
        /// Comando para agregar una persona a la base de datos 
        /// </summary>
        public DelegateCommand ComandoAgregar { get { return comandoAgregar = new DelegateCommand(ComandoAgregar_Execute, ComandoAgregar_CanExecute); } }
        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; set => listadoDepartamentos = value; }
        #endregion
        #region commands
        #region comandoAgregar
        private bool ComandoAgregar_CanExecute()
        {
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && !string.IsNullOrEmpty(personaSeleccionada.Foto) && personaSeleccionada.FechaNacimiento < DateTime.Today; ;
        }
        private void ComandoAgregar_Execute()
        {
            try
            {
                gestoraBL.AgregarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                PersonaSeleccionada = ListadoPersonas[0];
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
        }
        #endregion
        #region comandoAlterar
        public void ComandoAlterar_Execute()
        {
            try
            {
                gestoraBL.EditarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                PersonaSeleccionada = ListadoPersonas[0];
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");//Revisar, que tipo de excepciones he de controlar
                _ = messageDialog.ShowAsync();
            }

            NotifyPropertyChanged("PersonaSeleccionada");
        }

        public bool ComandoAlterar_CanExecute()
        {
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && !string.IsNullOrEmpty(personaSeleccionada.Foto) &&  personaSeleccionada.FechaNacimiento < DateTime.Today;
        }
        #endregion
        #region comandoBorrar
        public void ComandoBorrar_Execute()
        {
            try
            {
                gestoraBL.EliminarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                PersonaSeleccionada = ListadoPersonas[0];
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");//Revisar, que tipo de excepciones he de controlar
                _ = messageDialog.ShowAsync();
            }
        }
        public bool ComandoBorrar_CanExecute()
        {
            return personaSeleccionada != null;
        }
        #endregion
        #endregion
    }
}
