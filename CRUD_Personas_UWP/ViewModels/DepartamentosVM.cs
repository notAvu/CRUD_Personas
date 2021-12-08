using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CRUD_Personas_BL;
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
    public class DepartamentosVM : clsVMBase
    {
        #region propiedades privadas
        clsGestoraDptosBL gestoraDptos;
        clsListadoDptosBL dptosBL;
        List<clsDepartamento> listadoDepartamentos;
        clsListadoPersonasBL personasBl;
        clsPersona personaSeleccionada;
        List<clsPersona> listadoPersonas;
        List<clsPersona> listadoFiltrado;
        clsDepartamento dptoSeleccionado;
        DelegateCommand comandoAgregarDpto;
        DelegateCommand comandoAlterarDpto;
        DelegateCommand comandoBorrarDpto;
        #endregion
        #region constructor
        public DepartamentosVM()
        {
            try
            {
                dptosBL = new clsListadoDptosBL();
                listadoDepartamentos = dptosBL.ListadoCompleto();
                gestoraDptos = new clsGestoraDptosBL();
                personasBl = new clsListadoPersonasBL();
                listadoPersonas = personasBl.ListadoCompleto();
                DptoSeleccionado = listadoDepartamentos[0];

            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
        }
        #endregion
        #region propiedades publicas
        public clsDepartamento DptoSeleccionado
        {
            get => dptoSeleccionado;
            set
            {
                dptoSeleccionado = value;
                NotifyPropertyChanged("DptoSeleccionado");
                if (dptoSeleccionado != null)
                {
                    ListadoFiltrado = new List<clsPersona>(listadoPersonas.Where(persona => persona.IdDepartamento == dptoSeleccionado.Id));
                }
            }
        }
        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; set => listadoDepartamentos = value; }

        /// <summary>
        /// Comando para agregar un departamento a la base de datos
        /// </summary>
        public DelegateCommand ComandoAgregarDpto { get { return comandoAgregarDpto = new DelegateCommand(ComandoAgregarDpto_Execute, ComandoAgregarDpto_CanExecute); } }
        /// <summary>
        /// Comando para editar los datos de un departamento en la base de datos
        /// </summary>
        public DelegateCommand ComandoAlterarDpto { get { return comandoAlterarDpto = new DelegateCommand(ComandoAlterarDpto_Execute, ComandoAlterarDpto_CanExecute); } }
        /// <summary>
        /// Comando para borrar un departamento de la base de datos
        /// </summary>
        public DelegateCommand ComandoBorrarDpto { get { return comandoBorrarDpto = new DelegateCommand(ComandoBorrarDpto_Execute, ComandoBorrarDpto_CanExecute); } }

        public List<clsPersona> ListadoFiltrado
        {
            get => listadoFiltrado; set
            {
                listadoFiltrado = value;
                personaSeleccionada = listadoFiltrado[0];
                NotifyPropertyChanged("ListadoFiltrado");
            }
        }


        #endregion
        #region parametros comandoAgregarDpto
        private bool ComandoAgregarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }
        private void ComandoAgregarDpto_Execute()
        {
            try
            {
                gestoraDptos.AgregarDepartamento(DptoSeleccionado);
                ListadoDepartamentos = new clsListadoDptosBL().ListadoCompleto();
                DptoSeleccionado = ListadoDepartamentos[0];
                NotifyPropertyChanged("ListadoDepartamentos");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
        }
        #endregion
        #region parametros comandoBorrarDpto
        private bool ComandoBorrarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }

        private void ComandoBorrarDpto_Execute()
        {
            try
            {
                gestoraDptos.EliminarDepartamento(DptoSeleccionado);
                ListadoDepartamentos = new clsListadoDptosBL().ListadoCompleto();
                DptoSeleccionado = ListadoDepartamentos[0];
                NotifyPropertyChanged("ListadoDepartamentos");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
        }
        #endregion
        #region parametros comandoAlterarDpto
        private bool ComandoAlterarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }

        private void ComandoAlterarDpto_Execute()
        {
            try
            {
                gestoraDptos.EditarDepartamento(DptoSeleccionado);
                ListadoDepartamentos = new clsListadoDptosBL().ListadoCompleto();
                DptoSeleccionado = ListadoDepartamentos[0];
                NotifyPropertyChanged("ListadoDepartamentos");
            }
            catch
            {
                var messageDialog = new MessageDialog("No ha sido posible conectar a la BBDD por favor intententelo de nuevo mas tarde");
                _ = messageDialog.ShowAsync();
            }
        }
        #endregion 
    }
}
