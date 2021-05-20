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
