using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vuelos.Models
{
    public class ReservaViewModel
    {
        public string UserId { get; set; }
        public int IdCompraVuelos { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Dni { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }
        public string Imagen { get; set; }
    }
}
