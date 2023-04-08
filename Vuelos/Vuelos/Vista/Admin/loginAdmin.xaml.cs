using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos.Vista.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class loginAdmin : ContentPage
	{
		public loginAdmin ()
		{
			InitializeComponent ();
		}

        private async void btnSesion_Clicked(object sender, EventArgs e)
        {
            string RolAdmin = txtRolAdmin.Text;
            string ContrasenaAdministrador = txtContrasenaAdministrador.Text;
            var uno = await App.SQLiteDB.VerifyAdministradorCredentialsAsync(RolAdmin, ContrasenaAdministrador);
            if (uno)
            {
                await Navigation.PushModalAsync(new PantallaInicio());
            }
            else
            {
                await DisplayAlert("Error", "Rol Admin y/o Contraseña incorrectos", "Ok");
            }
        }

        private async void btnRegistroLoginAdmin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Volver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}