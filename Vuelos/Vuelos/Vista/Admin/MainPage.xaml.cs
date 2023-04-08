using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuelos.Models;
using Xamarin.Forms;

namespace Vuelos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            llenarDatos();
        }
        public async void llenarDatos()
        {
            var AdministradorList = await App.SQLiteDB.GetAdministradorAsync();
            if (AdministradorList != null)
            {
                lstAdministrador.ItemsSource = AdministradorList;
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Administrador Admin = new Administrador
                {
                    RolAdmin=txtAdministrador.Text,
                    ContrasenaAdmin= txtContrasenaAdministrador.Text,
                };
                await App.SQLiteDB.SaveAdministradorAsync(Admin);
                
                await DisplayAlert("Registro", "Se Guardo de manera exitosa", "ok");
                LimpiarControles();
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar tods los datos", "ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtAdministrador.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtContrasenaAdministrador.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtIdAdministrador.Text))
            {
                Administrador Admin = new Administrador()
                {
                    IdAdministrador = Convert.ToInt32(txtIdAdministrador.Text),
                    RolAdmin = txtAdministrador.Text,
                    ContrasenaAdmin = txtContrasenaAdministrador.Text
                };
                await App.SQLiteDB.SaveAdministradorAsync(Admin);
                await DisplayAlert("Registro", "Se ha actualizado de manera Exitosa", "ok");

                LimpiarControles();
                txtIdAdministrador.IsVisible = true;
                btnActualizar.IsVisible = true;
                btnRegistrar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void lstAdministrador_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj=(Administrador)e.SelectedItem;
            btnRegistrar.IsVisible= true;
            txtIdAdministrador.IsVisible= true;
            btnActualizar.IsVisible= true;
            btnEliminar.IsVisible= true;
            if (!string.IsNullOrEmpty(obj.IdAdministrador.ToString()))
            {
                var Administrador = await App.SQLiteDB.GetAdministradorByIdAsync(obj.IdAdministrador);
                if (Administrador != null)
                {
                    txtIdAdministrador.Text=Administrador.IdAdministrador.ToString();
                    txtAdministrador.Text=Administrador.RolAdmin;
                    txtContrasenaAdministrador.Text=Administrador.ContrasenaAdmin;
                }
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var Administrador = await App.SQLiteDB.GetAdministradorByIdAsync(Convert.ToInt32(txtIdAdministrador.Text));
            if (Administrador != null) 
            {
                await App.SQLiteDB.DeleteAdministradorAsync(Administrador);
                await DisplayAlert("Alumno", "Se Elimino de manera exitosa", "ok");
                LimpiarControles();
                llenarDatos();
                btnRegistrar.IsVisible = true;
                txtIdAdministrador.IsVisible = true;
                btnActualizar.IsVisible = true;
                btnEliminar.IsVisible = true;
            }
        }
        public void LimpiarControles()
        {
            txtIdAdministrador.Text = "";
            txtAdministrador.Text = "";
            txtContrasenaAdministrador.Text = "";
        }
    }
}
