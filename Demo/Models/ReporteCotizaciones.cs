using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ReporteCotizaciones
    {
        public string folio { get; set; }
        public DateTime fecha { get; set; }
        public string cod_cte { get; set; }
        public string razon_social { get; set; }
        public decimal total { get; set; }
    }
}
