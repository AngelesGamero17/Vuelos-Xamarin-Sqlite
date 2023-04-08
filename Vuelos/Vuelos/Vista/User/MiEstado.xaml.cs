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
	public partial class MiEstado : ContentPage
	{
        private ResumenReservaViewModel viewModel;
        public MiEstado ()
		{
			InitializeComponent ();
            CargarReservasAsync();
        }
        private async void CargarReservasAsync()
        {
            // Obtener la lista de reservas y actualizar la propiedad ServiciosVuelos
            var reservas = await App.SQLiteDB.GetReservasByUserIdAsync(App.AppContext.UserId);
            var cuatro = new List<cuatro>();

            foreach (var reserva in reservas)
            {
                var servicio = await App.SQLiteDB.GetCuatroByIdAsync(reserva.IdCompraVuelos);
                cuatro.Add(servicio);
            }

            viewModel = new ResumenReservaViewModel(cuatro);
            BindingContext = viewModel;
        }

        private void CancelarVuelos_Clicked(object sender, EventArgs e)
        {

        }
    }
}