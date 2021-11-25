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
        PersonasBL gestoraPersonas = new PersonasBL();
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
                listadoPersonas = gestoraPersonas.ListadoCompleto();
                this.listadoDepartamentos = new clsListadoDepartamentos().ListadoCompleto;
                personaSeleccionada = listadoPersonas[0];
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                messageDialog.ShowAsync();
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
                comandoBorrar.RaiseCanExecuteChanged();
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
            return !string.IsNullOrEmpty(personaSeleccionada.Nombre) && !string.IsNullOrEmpty(personaSeleccionada.Apellido) && personaSeleccionada.FechaNacimiento < DateTime.Today; ;
        }
        private void ComandoAgregar_Execute()
        {
            try
            {
                gestoraPersonas.AgregarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                messageDialog.ShowAsync();
                //Revisar, que tipo de excepciones he de controlar (si es generico, declarar el mensaje atributo de la clase)
            }
        }
        #endregion
        #region comandoAlterar
        public void ComandoAlterar_Execute()
        {
            try
            {
                gestoraPersonas.EditarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");//Revisar, que tipo de excepciones he de controlar
                messageDialog.ShowAsync();
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
            try
            {
                gestoraPersonas.EliminarPersona(personaSeleccionada);
                ListadoPersonas = new clsListadoPersonas().ListadoCompleto;
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");//Revisar, que tipo de excepciones he de controlar
                messageDialog.ShowAsync();
            }
        }
        public bool ComandoBorrar_CanExecute()
        {
            return personaSeleccionada != null;
        }
        #endregion
        #endregion
        #region departamentoPersonaSeleccionada
        ///// <summary>
        ///// Metodo que devuelve los datos del departamento que corresponde a la persona seleccionada
        ///// </summary>
        ///// <returns></returns>
        //public clsDepartamento DepartamentoPersonaSeleccionada()
        //{
        //    clsDepartamento departamento = null;
        //    try
        //    {
        //        departamento = gestoraDepartamentos.DepartamentoPorId(PersonaSeleccionada.IdDepartamento);
        //    }
        //    catch
        //    {
        //        var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");//Revisar, que tipo de excepciones he de controlar
        //        messageDialog.ShowAsync();
        //    }
        //    return departamento;
        //}
        #endregion
    }
}
