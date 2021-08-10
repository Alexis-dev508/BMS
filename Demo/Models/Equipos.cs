using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Equipos
    {
        public string equipo { get; set; }
        public string nombre { get; set; }
        public string abreviatura { get; set; }
        public string tipo_equipo { get; set; }
        public string tipo_vehiculo { get; set; }
        public string marca{ get; set; }
        public string modelo { get; set; }
        public string año{ get; set; }
        public string serie { get; set; }
        public string motor { get; set; }
        public string caracteristicas { get; set; }
        public string placas { get; set; }
        public Int64 ultima_lectura { get; set; }
        public decimal seguro { get; set; }
        public decimal tenencia { get; set; }
        public string chofer { get; set; }
        public string status { get; set; }
        public string activo_fijo { get; set; }
        public Boolean es_activo_fijo { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_alta { get; set; }
        public string cod_estab { get; set; }
        public string uso_equipos { get; set; }
        public string codigo_economico { get; set; }
        public string empleado { get; set; }
        public string nombre_empleado { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha_compra { get; set; }
        public decimal costo { get; set; }
        public decimal valor_comercial { get; set; }
        public decimal abono_mensual { get; set; }
        public string carga_estandar { get; set; }
        public string equipo_depende{ get; set; }
        public int vida_util { get; set; }
        public string medida_vida_util { get; set; }
        public int garantia { get; set; }
        public string medida_garantia { get; set; }
        public string lote { get; set; }
        public int tanque1 { get; set; }
        public int tanque2 { get; set; }
        public int tanque3 { get; set; }
        public string combustible1 { get; set; }
        public string combustible2 { get; set; }
        public string combustible3 { get; set; }
        public Int32 nivel_licencia { get; set; }
        public Int32 nivel_licencia_empresa { get; set; }
        public Boolean usa_lubricante { get; set; }
        [DataType(DataType.Date)]
        public DateTime vigencia_placas { get; set; }
        [DataType(DataType.Date)]
        public DateTime vigencia_circulacion { get; set; }
        public int vida_util2 { get; set; }
        public string medida_vida_util2 { get; set; }
        public int garantia2 { get; set; }
        public string medida_garantia2 { get; set; }
        public string area { get; set; }
        public string departamento { get; set; }
        public string tarjeta { get; set; }
        public string ayudante { get; set; }
        public decimal RENDIMIENTO1 { get; set; }
        public decimal RENDIMIENTO2 { get; set; }
        public decimal RENDIMIENTO3 { get; set; }
        public int recorrido_maximo { get; set;}
        public string version { get; set; }
        public string odometro { get; set; }
        public Int32 llantas { get; set; }
        public Int32 llantas_extras { get; set; }
        public Int32 llantas_eje1 { get; set; }
        public Int32 llantas_eje2 { get; set; }
        public Int32 llantas_eje3 { get; set; }
        public Int32 llantas_eje4 { get; set; }
        public Int32 llantas_eje5 { get; set; }
        public Int32 llantas_eje6 { get; set; }
        public string color { get; set; }
        public string ayudante2 { get; set; }
        public Boolean sirve_odometro { get; set; }
        public string NombreAF { get; set; }
        public string NombreAR { get; set; }
        public string NombreDE { get; set; }
        public string NombreDD { get; set; }
        public string Nombre_Chofer { get; set; }


    }
}
