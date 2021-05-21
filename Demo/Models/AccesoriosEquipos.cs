using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class AccesoriosEquipos
    {
        //accesorios_por_equipo.equipo, accesorios_por_equipo.accesorio_equipos, accesorios_por_equipo.cantidad,
        //accesorios_por_equipo.valor, accesorios_por_equipo.fecha, accesorios_equipos.nombre, tipos_equipo.nombre AS Tipo_equipo
        public string equipo { get; set; }
        public string accesorio { get; set; }
        public decimal cantidad { get; set; }
        public decimal valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string Tipo_equipo { get; set; }

    }
}
