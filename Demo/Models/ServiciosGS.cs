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
    }
}
