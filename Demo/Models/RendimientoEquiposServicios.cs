using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class RendimientoEquiposServicios
    {
        public string equipo { get; set; }
        public string nombre { get; set; }
        public string cod_eco { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string placas { get; set; }
        public int lectura_ini { get; set; }
        public int lectura_fin { get; set; }
        public int dist_recorrida { get; set; }
        public int servicios { get; set; }
        public decimal cantidad { get; set; }
        public decimal importe { get; set; }
        public decimal rend_cant { get; set; }
        public decimal rend_imp { get; set; }

        public string servicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_ini { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_fin { get; set; }

    }
}
