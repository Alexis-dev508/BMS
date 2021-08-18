using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ReporteRendimientoEquiposModelView
    {
        public ReporteRendimientoEquiposModelView() {
            this.Datos = new List<RendimientoEquiposServicios>();
        }
      
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string servicio { get; set; }
        public string nombre { get; set; }
        public List<RendimientoEquiposServicios> Datos { get; set; }
    }
}
