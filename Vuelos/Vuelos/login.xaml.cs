using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class login : ContentPage
	{
		public login ()
		{
			InitializeComponent ();
		}

        private async void btnRegristroLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private async
            void btnSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            var uno = await App.SQLiteDB.VerifyUnoCredentialsAsync(usuario, contrasena);
            if (uno)
            {
                await Navigation.PushModalAsync(new PantallaInicio());
            }
            else
            {
                await DisplayAlert("Error", "Usuario y/o Contraseña incorrectos", "Ok");
            }
        }
    }
}