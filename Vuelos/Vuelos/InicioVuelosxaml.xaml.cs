using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Vista.Admin;
using Vuelos.Vista.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InicioVuelosxaml : ContentPage
	{
		public InicioVuelosxaml ()
		{
			InitializeComponent ();
		}

        private async void IngresoAmin_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new loginAdmin());
        }

        private async void IngresoUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new logearUsuario());
        }
    }
}