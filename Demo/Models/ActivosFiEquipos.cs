using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ActivosFiEquipos
    {
        //activo_fijo, fecha, descripcion, marca, modelo, talla, color, serie, motor, tipo_activo_fijo, transaccion, cod_estab, ubicacion,
        //fecha_adquisicion, monto_original_inversion, usuario, usuario_baja, fecha_baja, fecha_modificacion, status, empleado
        public string activo_fijo { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string talla { get; set; }
        public string color { get; set; }
        public string serie { get; set; }
        public string motor { get; set; }
        public string tipo_activo_fijo { get; set; }
        public string transaccion { get; set; }
        public string cod_estab { get; set; }
        public string ubicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_adquisicion { get; set; }
        public decimal monto_original_inversion { get; set; }
        public string usuario { get; set; }
        public string usuario_baja { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_baja { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_modificacion { get; set; }
        public string status { get; set; }
        public string empleado { get; set; }




    }
}
