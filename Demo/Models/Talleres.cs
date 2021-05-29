using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Talleres
    {
        public  string servicio { get; set; }
        public string nombre { get; set; }
        public string status { get; set; }
        public string concepto_gastos { get; set; }
        public int horas_mecanico { get; set; }
        public int minutos_mecanico { get; set; }
        public int orden_mostrar { get; set; }
        public string concepto_servicio { get; set; }
        public string sistema_equipos { get; set; }
        [DataType(DataType.Date)]
        public DateTime dias { get; set; }
        public decimal precio { get; set; }
    }
}
