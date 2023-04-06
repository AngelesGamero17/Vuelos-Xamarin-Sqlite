using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Vuelos.Models;

namespace Vuelos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PantallaInicio : ContentPage
	{
		public PantallaInicio ()
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
        private async void btnRegistrar_Clicked_1(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                cuatro four = new cuatro
                {
                    NombreVuelos = txtNombreVuelos.Text,
                    Precio = txtPrecio.Text,
                    Estado = txtEstado.Text,
                    Imagen = txtImagen.Text,
                };
                await App.SQLiteDB.SaveCuatroAsync(four);

                await DisplayAlert("Registro", "Se Guardo de manera exitosa", "ok");
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombreVuelos.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEstado.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtImagen.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }


        private async void txtCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCuatro.Text))
            {
                cuatro four = new cuatro()
                {
                    IdCompraVuelos = Convert.ToInt32(txtIdCuatro.Text),
                    NombreVuelos = txtNombreVuelos.Text,
                    Precio = txtPrecio.Text,
                    Estado = txtEstado.Text,
                    Imagen = txtImagen.Text,
                };
                object value = await App.SQLiteDB.SaveCuatroAsync(four);
                await DisplayAlert("Registro", "Se ha actualizado de manera Exitosa", "ok");

                LimpiarControles();
                txtIdCuatro.IsVisible = true;
                btnActualizar.IsVisible = true;
                btnRegistrar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void lstCuatro_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (cuatro)e.SelectedItem;
            txtIdCuatro.IsVisible = true;
            btnRegistrar.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdCompraVuelos.ToString()))
            {
                var cuatro = await App.SQLiteDB.GetCuatroByIdAsync(obj.IdCompraVuelos);
                if (cuatro != null)
                {
                    txtIdCuatro.Text = cuatro.IdCompraVuelos.ToString();
                    txtNombreVuelos.Text = cuatro.NombreVuelos;
                    txtPrecio.Text = cuatro.Precio;
                    txtEstado.Text = cuatro.Estado;
                    txtImagen.Text = cuatro.Imagen;
                }
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            {
                var cuatro = await App.SQLiteDB.GetCuatroByIdAsync(Convert.ToInt32(txtIdCuatro.Text));
                if (cuatro != null)
                {
                    await App.SQLiteDB.DeleteCuatroAsync(cuatro);
                    await DisplayAlert("Alumno", "Se Elimino de manera exitosa", "ok");
                    LimpiarControles();
                    llenarDatos();
                    btnRegistrar.IsVisible = true;
                    txtIdCuatro.IsVisible = true;
                    btnActualizar.IsVisible = true;
                    btnEliminar.IsVisible = true;
                }
            }
    }
        public void LimpiarControles()
        {
            txtIdCuatro.Text = "";
            txtNombreVuelos.Text = "";
            txtPrecio.Text = "";
            txtEstado.Text = "";
            txtImagen.Text = "";
        }

    }
}