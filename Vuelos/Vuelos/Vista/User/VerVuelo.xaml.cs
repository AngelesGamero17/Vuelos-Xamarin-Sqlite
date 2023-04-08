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
	public partial class VerVuelo : ContentPage
	{
		public VerVuelo ()
		{
			InitializeComponent ();
            llenarDatos();
        }
        public async void llenarDatos()
        {
            var cuatroList = await App.SQLiteDB.GetCuatroAsync();
            if (cuatroList != null)
            {
                lstCuatro.ItemsSource = cuatroList;
            }
        
    }

        private async void Reservar_Clicked(object sender, EventArgs e)
        {
            var selectedVuelo = (cuatro)((Button)sender).BindingContext;
            if (string.IsNullOrEmpty(App.AppContext.UserId))
            {
                await DisplayAlert("Error", "No se ha iniciado sesión.", "OK");
                return;
            }

            if (await App.SQLiteDB.SaveReservaAsync(selectedVuelo, App.AppContext.UserId))
            {
                await DisplayAlert("Compra realizada", "Se ha realizado la compra con éxito.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo realizar la reservación.", "OK");
            }
        }
    }
}