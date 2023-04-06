using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Vuelos.Models
{
    public class cuatro
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompraVuelos { get; set; }
        [MaxLength(30)]
        public string NombreVuelos { get; set; }
        [MaxLength(30)]
        public string Precio { get; set; }
        [MaxLength(30)]
        public string Estado { get; set; }
        [MaxLength(30)]
        public string Imagen { get; set; }

    }
}
