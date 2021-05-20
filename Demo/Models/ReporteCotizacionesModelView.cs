using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ReporteCotizacionesModelView
    {
        public ReporteCotizacionesModelView()
        {
            this.Datos = new List<ReporteCotizaciones>();
        }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public List<ReporteCotizaciones> Datos { get; set; }

    }
}
