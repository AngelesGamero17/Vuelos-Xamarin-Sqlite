using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vuelos.Vista.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCompra : ContentPage
    {
        public ListaCompra()
        {
            InitializeComponent();
            BindingContext = new ListaVuelosReservadosViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Obtener las reservas del usuario actual
            // Reemplaza con el ID del usuario actual
            var reservas = await App.SQLiteDB.GetReservacionByUserIdAsync();

            if (reservas != null && reservas.Any())
            {
                await DisplayAlert("Compras", $"Se encontraron {reservas.Count} Compras", "OK");
                var viewModel = (ListaVuelosReservadosViewModel)BindingContext;
                viewModel.reservas = reservas;
                lsServiciosVuelos.ItemsSource = viewModel.reservas;
            }
            else
            {
                await DisplayAlert("Reservas", "No se encontraron Compras", "OK");
            }

            // Establecer la lista de reservas como el BindingContext de la página

        }


        public class ListaVuelosReservadosViewModel
        {
            public List<ReservaViewModel> reservas { get; set; }

            public ListaVuelosReservadosViewModel()
            {
                // Inicializar la lista de reservas aquí
                reservas = new List<ReservaViewModel>();
            }
        }
    }
}