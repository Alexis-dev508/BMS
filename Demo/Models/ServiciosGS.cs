using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class ServiciosGS
    {
        public ServiciosGS()
        {

        }
        public int id { get; set; }
        [Required]
        public string servicio { get; set; }
        public string servicioN { get; set; }
        [Required]
        public int lectura { get; set; }
        [Required]
        public decimal cantidad { get; set; }
        [Required]
        public decimal importe { get; set; }
        public decimal Descporcent { get; set; }
        public decimal Descuni { get; set; }
        public decimal NetoServ { get; set; }

        public string notasserv { get; set; }
        public decimal iva { get; set; }
        public decimal iva_ret { get; set; }
        public decimal isr_ret { get; set; }
        public string concepto { get; set; }
        public string mecanico { get; set; }
        public decimal refacciones { get; set; }
        public decimal mano_obra_mecanico { get; set; }
        public decimal mano_obra_total { get; set; }
        public decimal trabajos_otros_talleres { get; set; }
        public decimal otros_gastos { get; set; }
        public decimal costo { get; set; }
        public decimal horas_mecanico { get; set; }
        public decimal costo_hora_mecanico { get; set; }
    }
}
