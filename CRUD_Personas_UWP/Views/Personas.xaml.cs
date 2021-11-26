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
    public sealed partial class Personas : Page
    {
        PersonasVM viewModel;
        public Personas()
        {
            this.InitializeComponent();
            viewModel = (PersonasVM)DataContext;
            //viewModel.PersonaSeleccionada = viewModel.ListadoPersonas[0];
        }
        /// <summary>
        /// Metodo asociado al click de un elemento de la lista de personas en la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewModel.PersonaSeleccionada = sender as clsPersona;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PersonaSeleccionada = new clsPersona();
            alterBtn.Visibility = Visibility.Collapsed;
            agregarBtn.Visibility = Visibility.Visible;
            alterBtn.IsEnabled = false;
            agregarBtn.IsEnabled = true;
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NombreTbx.Text) && !string.IsNullOrEmpty(ApellidoTbx.Text) && !string.IsNullOrEmpty(ImgUrlTbx.Text) && FechaNacimientoDp.Date < DateTime.Now)
            {
                agregarBtn.Visibility = Visibility.Collapsed;
                alterBtn.Visibility = Visibility.Visible;
                fotoImg.Visibility = Visibility.Visible;
                alterBtn.IsEnabled = true;
                agregarBtn.IsEnabled = false;

                errorMsg.Visibility = Visibility.Collapsed;
            }
            CheckEmpty(NombreTbx);
            CheckEmpty(ApellidoTbx);
            CheckEmpty(ImgUrlTbx);
        }

        private void CheckEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                errorMsg.Visibility = Visibility.Visible;
            }
            else
            {
                textBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
        }
    }
}
