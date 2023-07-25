using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoaplicaciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menuprincipal : ContentPage
    {
        public menuprincipal()
        {
            InitializeComponent();

        }

        private void btniniciar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new login());
        }
    }
}