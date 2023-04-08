using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Vuelos.Models
{
    public class uno
    {
        [PrimaryKey, AutoIncrement]
        public int IdVuelos { get; set; }
        [MaxLength(30)]
        public string Nombre { get; set; }
        [MaxLength(30)]
        public string ApellidoPaterno { get; set; }
        [MaxLength(30)]
        public string ApellidoMaterno { get; set; }
        [MaxLength(30)]
        public string Edad { get; set; }
        [MaxLength(30)]
        public string Dni { get; set; }
        [MaxLength(30)]
        public string Fecha { get; set;}
        [MaxLength(30)]
        public string Usuario { get; set; }
        [MaxLength(30)]
        public string Contrasena { get; set; }
        [OneToMany]
        public List<Reserva> Reservas { get; set; }
    }

}
