using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class DetalleRendimiento
    {
        public string folio { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string operador { get; set; }
        public string nombre { get; set; }
        public Int32 lectura { get; set; }
        public decimal cantidad { get; set; }
        public decimal importe { get; set; }
        public decimal rend_can { get; set; }
        public decimal rend_acum { get; set; }
        public string notasservicio { get; set; }
        public string notas { get; set; }
    }
}
