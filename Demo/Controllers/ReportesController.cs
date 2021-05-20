using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class ReportesController :Controller
    {
        private readonly IConfiguration _configuration;
        private ReportesData datos;
        public ReportesController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.datos = new ReportesData(_configuration);
        }
        //cotizaciones
        public IActionResult ReporteCotizaciones()
        {
            ReporteCotizacionesModelView model = new ReporteCotizacionesModelView();
            model.FechaInicial = DateTime.Now;
            model.FechaFinal = DateTime.Now;
            return View(model);
        }
        //pedidos
        public IActionResult ReportePedidos()
        {
            ReportePedidosModelView model = new ReportePedidosModelView();
            model.FechaInicial = DateTime.Now;
            model.FechaFinal = DateTime.Now;
            return View(model);
        }
        //cotizaciones
        [HttpPost]
        public IActionResult ReporteCotizaciones(ReporteCotizacionesModelView model)
        {
            try
            {
                model.Datos = datos.TraerReporteCotizaciones(model.FechaInicial.Date, model.FechaFinal.Date.AddDays(1).AddMinutes(-1));
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
            }
           
            
            return View(model);
        }
        //pedidos
        [HttpPost]
        public IActionResult ReportePedidos(ReportePedidosModelView model)
        {
            try
            {
                model.Datos = datos.TraerReportePedidos(model.FechaInicial.Date, model.FechaFinal.Date.AddDays(1).AddMinutes(-1));
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
            }


            return View(model);
        }
        //cotizaciones
        [HttpGet]
        public IActionResult DetalleCotizacion(string folio)
        {
            List<DetalleCotizacion> detalle = new List<DetalleCotizacion>();
            try
            {
                detalle = datos.DetalleCotiz(folio);
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_DetalleCotizacion", detalle);
        }
        //pedidos
            [HttpGet]
        public IActionResult DetallePedido(string folio)
        {
            List<DetallePedido> detalle = new List<DetallePedido>();
            try
            {
                detalle = datos.DetallePed(folio);
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_DetallePedido", detalle);
        }
    }
}
