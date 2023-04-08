using System;
using System.Collections.Generic;
using System.Text;

namespace Vuelos.Models
{
    public class ResumenReservaViewModel
    {
        public List<cuatro> cuatro { get; set; }

        public ResumenReservaViewModel(List<cuatro> cuatro)
        {
            this.cuatro = cuatro;
        }
    }
}
