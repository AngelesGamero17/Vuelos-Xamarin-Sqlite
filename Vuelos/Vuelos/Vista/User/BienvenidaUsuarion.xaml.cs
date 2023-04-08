using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos.Vista.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BienvenidaUsuarion : ContentPage
	{
        public BienvenidaUsuarion()
        {
            InitializeComponent();
            lol.Text = App.AppContext.UserId;

        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void VerVueloDisponibles_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerVuelo());
        }

        private async void MiEstado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MiEstado());
        }
    }
}