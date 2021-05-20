using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class DetalleCotizacion
    {

        public string cod_prod { get; set; }
        public string descripcion_completa { get; set; }
        public decimal cantidad { get; set; }
        public string unidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
    }
}
