using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos.Vista.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class logearUsuario : ContentPage
	{
		public logearUsuario ()
		{
			InitializeComponent ();
		}

        private async void btnSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            var uno = await App.SQLiteDB.VerifyUnoCredentialsAsync(usuario, contrasena);
            if (uno)
            {
                App.AppContext.UserId = SessionActiva.UserId.ToString();
                await Navigation.PushModalAsync(new BienvenidaUsuarion());
            }
            else
            {
                await DisplayAlert("Error", "Usuario y/o Contraseña incorrectos", "Ok");
            }
        }

        private async void btnRegistroLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }

        private async void Volver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}