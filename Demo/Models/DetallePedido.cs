using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class DetallePedido
    {
        
        public string cod_prod { get; set; }
        public string descripcion_completa { get; set; }
        public decimal cantidad_autorizada { get; set; }
        public decimal cantidad_surtida { get; set; }
        public string unidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
        
    }
}
