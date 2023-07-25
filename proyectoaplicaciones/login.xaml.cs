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
	public partial class login : ContentPage
	{
		public login ()
		{
			InitializeComponent ();
		}
        private void OnLoginButtonClicked(object sender, System.EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (username == "admin" && password == "espe123")
            {
                // Credenciales válidas, navegar a la página de inicio (Home)
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Credenciales inválidas, mostrar mensaje de error
                DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos", "OK");
            }
        }
    }
}