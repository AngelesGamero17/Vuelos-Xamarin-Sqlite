using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace Vuelos.Models
{
     public class Reserva
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(cuatro))]
        public int IdCompraVuelos { get; set; }

        [ForeignKey(typeof(uno))]
        public string UserId { get; set; }
    }
}
