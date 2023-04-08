using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vuelos.Models
{
    public class Administrador
    {

        [PrimaryKey, AutoIncrement]
        public int IdAdministrador { get; set; }
        [MaxLength(30)]
        public string RolAdmin { get; set; }
        [MaxLength(30)]
        public string ContrasenaAdmin { get; set; }
    }
}
