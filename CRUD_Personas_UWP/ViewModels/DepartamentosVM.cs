﻿using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class DepartamentosVM : clsVMBase
    {
        #region propiedades privadas
        DepartamentosBL gestoraDepartamentos = new DepartamentosBL();
        List<clsDepartamento> listadoDepartamentos;
        clsDepartamento dptoSeleccionado;
        DelegateCommand comandoAgregarDpto;
        DelegateCommand comandoAlterarDpto;
        DelegateCommand comandoBorrarDpto;
        #endregion
        #region constructor
        public DepartamentosVM()
        {
            this.gestoraDepartamentos = new DepartamentosBL();
            this.listadoDepartamentos = gestoraDepartamentos.ListadoCompleto();
        }
        #endregion
        #region propiedades publicas
        public clsDepartamento DptoSeleccionado
        {
            get => dptoSeleccionado; set
            {
                dptoSeleccionado = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                comandoAlterarDpto.RaiseCanExecuteChanged();
                comandoBorrarDpto.RaiseCanExecuteChanged();
            }
        }
        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; set => listadoDepartamentos = value; }

        public DelegateCommand ComandoAgeragarDpto { get { return comandoAgregarDpto = new DelegateCommand(ComandoAgregarDpto_Execute, ComandoAgregarDpto_CanExecute); } }
        public DelegateCommand ComandoAlterarDpto { get { return comandoAlterarDpto = new DelegateCommand(ComandoAlterarDpto_Execute, ComandoAlterarDpto_CanExecute); } }
        public DelegateCommand ComandoBorrarDpto { get { return comandoBorrarDpto = new DelegateCommand(ComandoBorrarDpto_Execute, ComandoBorrarDpto_CanExecute); } }
        #endregion
        #region parametros comandoAgregarDpto
        private bool ComandoAgregarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }
        private void ComandoAgregarDpto_Execute()
        {
            gestoraDepartamentos.AgregarDepartamento(dptoSeleccionado);
        }
        #endregion
        #region parametros comandoBorrarDpto
        private bool ComandoBorrarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }

        private void ComandoBorrarDpto_Execute()
        {
            gestoraDepartamentos.EliminarDepartamento(dptoSeleccionado);
        }
        #endregion
        #region parametros comandoAlterarDpto
        private bool ComandoAlterarDpto_CanExecute()
        {
            return dptoSeleccionado != null;
        }

        private void ComandoAlterarDpto_Execute()
        {
            gestoraDepartamentos.EditarDepartamento(dptoSeleccionado);
        }
        #endregion 
    }
}