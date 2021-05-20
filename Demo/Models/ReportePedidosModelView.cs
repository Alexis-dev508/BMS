using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ReportePedidosModelView
    {
        public ReportePedidosModelView()
        {
            this.Datos = new List<ReportePedidos>();
        }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public List<ReportePedidos> Datos { get; set; }
    }
}
