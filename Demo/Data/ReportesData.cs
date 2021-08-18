using Demo.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class ReportesData
    {
        private string ConnectionString;

        private readonly IConfiguration _configuration;

        public ReportesData(IConfiguration configuration)
        {
            _configuration = configuration;
            this.ConnectionString = _configuration.GetConnectionString("BMS");
        }

        //cotizaciones
        public List<ReporteCotizaciones>TraerReporteCotizaciones(DateTime fi, DateTime ff)
        {
            List<ReporteCotizaciones> rpt = new List<ReporteCotizaciones>();
            try
            {
                
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_ReporteCotiz", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@FI", fi);
                sda.SelectCommand.Parameters.AddWithValue("@FF", ff);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new ReporteCotizaciones
                {
                    folio = r["folio"].ToString().Trim(),
                    fecha = Convert.ToDateTime(r["fecha"]),
                    cod_cte = r["cod_cte"].ToString().Trim(),
                    razon_social = r["razon_social"].ToString().Trim(),
                    total = Convert.ToDecimal(r["total"])
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
        //pedidos 
        public List<ReportePedidos> TraerReportePedidos(DateTime fi, DateTime ff)
        {
            List<ReportePedidos> rpt = new List<ReportePedidos>();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_ReportePedido", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@FI", fi);
                sda.SelectCommand.Parameters.AddWithValue("@FF", ff);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new ReportePedidos
                {
                    folio = r["folio"].ToString().Trim(),
                    fecha = Convert.ToDateTime(r["fecha"]),
                    cod_cte = r["cod_cte"].ToString().Trim(),
                    razon_social = r["razon_social"].ToString().Trim(),
                    vendedor = r["vendedor"].ToString().Trim(),
                    nombre =r["nombre"].ToString().Trim(),
                    total = Convert.ToDecimal(r["total"]),
                    establecimiento = r["establecimiento"].ToString().Trim()
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
        //traer servicios
        public List<Servicios> TraerServicios()
        {
            List<Servicios> talleres = new List<Servicios>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Taller", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "R");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                talleres = dt.AsEnumerable().Select(a =>
                new Servicios
                {
                    servicio = a["servicio"].ToString(),
                    nombre = a["nombre"].ToString(),
                    tipo_servicio = a["tipo_servicio"].ToString(),
                    status = a["status"].ToString(),
                    horas_mecanico = Convert.ToInt32(a["horas_mecanico"]),
                    minutos_mecanico = Convert.ToInt32(a["minutos_mecanico"]),
                    concepto_servicio = a["concepto_servicio"].ToString(),
                    orden_mostrar = Convert.ToInt32(a["orden_mostrar"]),
                    dias = Convert.ToInt16(a["dias"]),
                    precio = Convert.ToDecimal(a["precio"]),
                    cs_nombre = a["cs_nombre"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return talleres;
        }
        //Rendimiento por equipos
        public List<RendimientoEquiposServicios> TraerReporteRendimiento(DateTime fi, DateTime ff, string servicio)
        {
            DateTime fecha1 = Convert.ToDateTime("01/01/1773");
            DateTime fecha2 = Convert.ToDateTime("31/12/9999");
            string fecha = DateTime.Today.ToString("dd-MM-yyyy");
            if (fi < fecha1)
            {
                fi = fecha1;
            }
            if (fi > fecha2)
            {
                fi = fecha2;
            }
            if (ff < fecha1)
            {
                ff = fecha1;
            }
            if (ff > fecha2)
            {
                ff = fecha2;
            }
            List<RendimientoEquiposServicios> rpt = new List<RendimientoEquiposServicios>();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_rendimiento_equipo", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@fecha_inicial", fi);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_final", ff);
                sda.SelectCommand.Parameters.AddWithValue("@oper", "P");
                sda.SelectCommand.Parameters.AddWithValue("@servicio", servicio);
                sda.SelectCommand.Parameters.AddWithValue("@equipo", "");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new RendimientoEquiposServicios
                {
                    equipo = r["equipo"].ToString().Trim(),
                    nombre = r["nombre"].ToString().Trim(),
                    cod_eco = r["codigo_economico"].ToString().Trim(),
                    marca = r["marca"].ToString().Trim(),
                    modelo = r["modelo"].ToString().Trim(),
                    placas = r["placas"].ToString().Trim(),
                    lectura_ini= Convert.ToInt32(r["lectura_ini"]),
                    lectura_fin = Convert.ToInt32(r["lectura_fin"]),
                    dist_recorrida = Convert.ToInt32(r["Recorrido"]),
                    servicios = Convert.ToInt32(r["servicios"]),
                    cantidad = Convert.ToDecimal(r["cantidad"]),
                    importe = Convert.ToDecimal(r["importe"]),
                    rend_cant = Convert.ToDecimal(r["rend_cant"]),
                    rend_imp = Convert.ToDecimal(r["rend_imp"]),                 
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
        //cotizaciones
        public List<DetalleCotizacion> DetalleCotiz(string folio)
        {
            List<DetalleCotizacion> rpt = new List<DetalleCotizacion>();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DetalleCotiz", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Folio", folio);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new DetalleCotizacion
                {
                    cod_prod = r["cod_prod"].ToString().Trim(),
                    descripcion_completa = r["descripcion_completa"].ToString().Trim(),
                    cantidad = Convert.ToDecimal(r["cantidad"]),
                    unidad = r["unidad"].ToString().Trim(),
                    precio = Convert.ToDecimal(r["precio"]),
                    total = Convert.ToDecimal(r["total"])
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
        //rendimiento
        public List<DetalleRendimiento> DetalleRend(string equipo, string servicio, DateTime fi, DateTime ff)
        {
            List<DetalleRendimiento> rpt = new List<DetalleRendimiento>();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_rendimiento_equipo", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", 'D');
                sda.SelectCommand.Parameters.AddWithValue("@equipo", equipo);
                sda.SelectCommand.Parameters.AddWithValue("@servicio", servicio);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_inicial", fi);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_final", ff);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new DetalleRendimiento
                {
                    folio = r["folio"].ToString(),
                    fecha = Convert.ToDateTime(r["fecha"]),
                    operador = r["operador"].ToString(),
                    nombre = r["nombre"].ToString(),
                    lectura = Convert.ToInt32(r["lectura"]),
                    cantidad = Convert.ToDecimal(r["cantidad"]),
                    importe = Convert.ToDecimal(r["total"]),
                    rend_can = Convert.ToDecimal(r["rend_can"]),
                    rend_acum = Convert.ToDecimal(r["rend_acum"]),
                    notasservicio = r["notas_servicio"].ToString(),
                    notas = r["notas"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
        //pedidos 
        public List<DetallePedido> DetallePed(string folio)
        {
            List<DetallePedido> rpt = new List<DetallePedido>();
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DetallePedido", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Folio", folio);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rpt = dt.AsEnumerable().Select(r => new DetallePedido
                {
                    cod_prod = r["cod_prod"].ToString().Trim(),
                    descripcion_completa = r["descripcion_completa"].ToString().Trim(),
                    cantidad_autorizada = Convert.ToDecimal(r["cantidad_autorizada"]),
                    cantidad_surtida = Convert.ToDecimal(r["cantidad_surtida"]),
                    unidad = r["unidad"].ToString().Trim(),
                    precio = Convert.ToDecimal(r["precio"]),
                    total = Convert.ToDecimal(r["total"]),

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rpt;
        }
    }
}
