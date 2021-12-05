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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace CRUD_Personas_UWP.Views.UserControls
{
    public sealed partial class ListadoPersonas : UserControl
    {
        public clsPersona MyProperty
        {
            get { return (clsPersona)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(clsPersona), typeof(PersonasVM),null);


        public ListadoPersonas()
        {
            this.InitializeComponent();
            //DataContextChanged += (s, e) => Bindings.Update();

        }
    }
}
