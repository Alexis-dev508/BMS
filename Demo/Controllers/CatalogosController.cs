using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class CatalogosController : Controller
    {
        private readonly IConfiguration _configuration;
        private CatalogosData datos;
        public CatalogosController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.datos = new CatalogosData(_configuration);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Aromas()
        {
            var model = datos.TraerAromas();
            return View(model);
        }
        [HttpGet]
        public IActionResult Sabores()
        {
            var model = datos.TraerSabores();
            return View(model);
        }
        [HttpGet]
        public IActionResult NuevoAroma()
        {
            
            var model = new AromasModelView();
            model.status = "V";
            var sts = datos.TraerStatus();
            foreach (var st in sts)
            {
                model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult NuevoSabor()
        {
            var model = new SaboresModelView();
            model.status = "V";
            var sts = datos.TraerStatus();
            foreach (var st in sts)
            {
                model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuevoAroma(AromasModelView model)
        {
            try
            {
                //llenar combo de status
                var sts = datos.TraerStatus();
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                var res = datos.GuardarAroma(model, "N");
                if (res)
                {
                    return RedirectToAction("Aromas");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuevoSabor(SaboresModelView model)
        {
            try
            {
                var sts = datos.TraerStatus();
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                var res = datos.GuardarSabor(model, "N");
                if (res)
                {
                    return RedirectToAction("Sabores");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }


        }
        //NUEVO!!!!
        [HttpGet]
        public IActionResult EditarAroma(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            var aroma = datos.TraerAroma(id);
            if (aroma == null)
            {
                //ViewBagErrores = "No existe el aroma";
                return NotFound();
            }
            var model = new AromasModelView() { aroma = aroma.aroma, nombre = aroma.nombre, abreviatura = aroma.abreviatura, status = aroma.status.Trim() };
            var sts = datos.TraerStatus();
            foreach (var st in sts)
            {
                model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status.Trim() });

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditarSabor(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var sabor = datos.TraerSabor(id);
            if (sabor == null)
            {
                //ViewBagErrores = "No existe el aroma";
                return NotFound();
            }
            var model = new SaboresModelView() { sabor = sabor.sabor, nombre = sabor.nombre, abreviatura = sabor.abreviatura, status = sabor.status.Trim() };
            var sts = datos.TraerStatus();
            foreach (var st in sts)
            {
                model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status.Trim() });

            }
            return View(model);
        }
        //NUEVO!!!!
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarAroma(AromasModelView model)
        {
            try
            {
                //llenar combo de status
                var sts = datos.TraerStatus();
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                var res = datos.GuardarAroma(model, "M");
                if (res)
                {
                    return RedirectToAction("Aromas");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarSabor(SaboresModelView model)
        {
            try
            {
                //llenar combo de status
                var sts = datos.TraerStatus();
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                var res = datos.GuardarSabor(model, "M");
                if (res)
                {
                    return RedirectToAction("Sabores");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }

        }
    }
}
