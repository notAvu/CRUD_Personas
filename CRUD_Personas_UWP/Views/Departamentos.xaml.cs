using CRUD_Personas_Entidades;
using CRUD_Personas_UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_Personas_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Departamentos : Page
    {
        DepartamentosVM viewModel;
        public Departamentos()
        {
            this.InitializeComponent();
            viewModel = (DepartamentosVM)DataContext;
            //viewModel.DptoSeleccionado = viewModel.ListadoDepartamentos[0];
        }
        private void listadoDptos_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewModel.DptoSeleccionado = sender as clsDepartamento;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DptoSeleccionado = new clsDepartamento();
            alterBtn.Visibility = Visibility.Collapsed;
            agregarBtn.Visibility = Visibility.Visible;
            alterBtn.IsEnabled = false;
            agregarBtn.IsEnabled = true;
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NombreTbx.Text))
            {
                agregarBtn.Visibility = Visibility.Collapsed;
                alterBtn.Visibility = Visibility.Visible;
                alterBtn.IsEnabled = true;
                agregarBtn.IsEnabled = false;
            }
        }
    }
}
