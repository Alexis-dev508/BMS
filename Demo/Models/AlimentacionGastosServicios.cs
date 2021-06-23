using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class AlimentacionGastosServicios
    {
        public string folio { get; set; }
        public string transaccion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_servicio { get; set; }
        public string equipo{ get; set; }
        public string usuario { get; set; }
        public string usuario_cancelacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_cancelacion { get; set; }
        public string cod_estab { get; set; }
        public string notas { get; set; }
        public string status { get; set; }
        public string cod_prv { get; set; }
        public DateTime fecha_elaboracion { get; set; }
        public string cod_cte { get; set; }
        public string recepcionista { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_recepcion { get; set; }
        public string torreta { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_entrega { get; set; }
        public string factura_proveedor { get; set; }
        public string servicio { get; set; }
        public string mecanico { get; set; }
        public decimal refacciones { get; set; }
        public decimal mano_obra_mecanico { get; set; }
        public decimal mano_obra_total { get; set; }
        public decimal trabajos_otros_talleres { get; set; }
        public decimal otros_gastos { get; set; }
        public int lectura { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public string operador { get; set; }
        public string tNombre { get; set; }
        public string sNombre { get; set; }
        public string eNombre { get; set; }
        public string pNombre { get; set; }



    }
}
