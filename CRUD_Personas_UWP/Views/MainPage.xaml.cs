﻿using System;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contentFme.Navigate(typeof(Views.Personas));
        }

        //private void PersonasNvi_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //}

        //private void DepartamentosNvi_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //}

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = (NavigationViewItem)sender.SelectedItem;
            if (item.Name.Equals("PersonasNvi"))
            {
                contentFme.Navigate(typeof(Views.Personas));
            }
            else
            {
                contentFme.Navigate(typeof(Views.Departamentos));
            }
        }
    }
}
