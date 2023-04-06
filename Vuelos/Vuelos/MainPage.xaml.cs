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
            var unoList = await App.SQLiteDB.GetUnoAsync();
            if (unoList != null)
            {
                lstUno.ItemsSource = unoList;
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                uno one = new uno
                {
                    Nombre=txtNombre.Text,
                    ApellidoPaterno=txtApellidoPaterno.Text,   
                    ApellidoMaterno=txtApellidoMaterno.Text,
                    Edad=txtEdad.Text,
                    Dni=txtDni.Text,
                    Fecha=txtFecha.Text,
                    Usuario=txtUsuario.Text,
                    Contrasena= txtContrasena.Text,
                };
                await App.SQLiteDB.SaveUnoAsync(one);
                
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
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty (txtApellidoMaterno.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if(string.IsNullOrEmpty(txtDni.Text))
            {
                respuesta=false;
            }
            else if(string.IsNullOrEmpty(txtFecha.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtContrasena.Text))
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
            if(!string.IsNullOrEmpty(txtIdUno.Text))
            {
                uno one = new uno()
                {
                    IdVuelos = Convert.ToInt32(txtIdUno.Text),
                    Nombre = txtNombre.Text,
                    ApellidoPaterno = txtApellidoPaterno.Text,
                    ApellidoMaterno = txtApellidoMaterno.Text,
                    Edad = txtEdad.Text,
                    Dni = txtDni.Text,
                    Fecha = txtFecha.Text,
                    Usuario = txtUsuario.Text,
                    Contrasena = txtContrasena.Text
                };
                await App.SQLiteDB.SaveUnoAsync(one);
                await DisplayAlert("Registro", "Se ha actualizado de manera Exitosa", "ok");

                LimpiarControles();
                txtIdUno.IsVisible = true;
                btnActualizar.IsVisible = true;
                btnRegistrar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void lstUno_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj=(uno)e.SelectedItem;
            btnRegistrar.IsVisible= true;
            txtIdUno.IsVisible= true;
            btnActualizar.IsVisible= true;
            btnEliminar.IsVisible= true;
            if (!string.IsNullOrEmpty(obj.IdVuelos.ToString()))
            {
                var uno = await App.SQLiteDB.GetUnoByIdAsync(obj.IdVuelos);
                if (uno != null)
                {
                    txtIdUno.Text=uno.IdVuelos.ToString();
                    txtNombre.Text=uno.Nombre;
                    txtApellidoPaterno.Text=uno.ApellidoPaterno;
                    txtApellidoMaterno.Text=uno.ApellidoMaterno;
                    txtEdad.Text=uno.Edad;
                    txtDni.Text=uno.Dni;
                    txtFecha.Text=uno.Fecha;
                    txtUsuario.Text=uno.Usuario;
                    txtContrasena.Text=uno.Contrasena;
                }
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var uno = await App.SQLiteDB.GetUnoByIdAsync(Convert.ToInt32(txtIdUno.Text));
            if (uno != null) 
            {
                await App.SQLiteDB.DeleteUnoAsync(uno);
                await DisplayAlert("Alumno", "Se Elimino de manera exitosa", "ok");
                LimpiarControles();
                llenarDatos();
                btnRegistrar.IsVisible = true;
                txtIdUno.IsVisible = true;
                btnActualizar.IsVisible = true;
                btnEliminar.IsVisible = true;
            }
        }
        public void LimpiarControles()
        {
            txtIdUno.Text = "";
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtEdad.Text = "";
            txtDni.Text = "";
            txtFecha.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }
    }
}
