using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Demo.Models
{
    public class AlimentacionGastosServicios
    {
        public int id { get; set; }
        [Key]
        public string folio { get; set; }
        public string folio_propio { get; set; }
        public string transaccion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_servicio { get; set; }
        [Required]
        public string equipo{ get; set; }
        public string usuario { get; set; }
        public string usuario_cancelacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_cancelacion { get; set; }
        public string cod_estab { get; set; }
        public string notas { get; set; }
        public string notas2 { get; set; }
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
        //[Required]
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
        //public string sNombre { get; set; }
        public string eNombre { get; set; }
        public string pNombre { get; set; }
        public string eqNombre { get; set; }

        public decimal importe { get; set; }
        public decimal Neto { get; set; }
        public decimal IVA { get; set; }
        public decimal IVARet { get; set; }
        public decimal ISRRet { get; set; }
        public virtual List<ServiciosGS> servicioGS { get; set; } = new List<ServiciosGS>();

        public string modelo { get; set; }

        public string marca { get; set; }

        public string chofer { get; set; }
        public string choferN { get; set; }
        public string serie { get; set; }
        public string año { get; set; }
        public string motor { get; set; }
        public string placas { get; set; }

    }
}
