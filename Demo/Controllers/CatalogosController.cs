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
        public EquiposModelView combos()
        {
            var model = new EquiposModelView();
            model.status = "V";
            //llenar DropDownList de marcas
            var marc = datos.TraerMarcas();
            foreach (var st in marc)
            {
                model.MarcasList.Add(new SelectListItem { Value = st.marca_equipo, Text = st.nombre });

            }
            //llenar DropDownList de versiones
            var vers = datos.TraerVersiones();
            foreach (var st in vers)
            {
                model.VersionList.Add(new SelectListItem { Value = st.version_equipos, Text = st.nombre });

            }
            //llenar DropDownList de modelos
            var mode = datos.TraerModelos();
            foreach (var st in mode)
            {
                model.ModelosList.Add(new SelectListItem { Value = st.modelo_equipos, Text = st.nombre });

            }
            //llenar DropDownList de años
            var annios = datos.TraerAnnios();
            foreach (var st in annios)
            {
                model.AnniosList.Add(new SelectListItem { Value = st.año_equipos, Text = st.año_equipos });
            }
            //llenar DropDownList de tipo Equipo
            var tipoE = datos.TraerTipoEquipo();
            foreach (var st in tipoE)
            {
                model.TipoEquipoList.Add(new SelectListItem { Value = st.tipo_equipo, Text = st.nombre });
            }
            //llenar DropDownList de usos
            var usos = datos.TraerUsos();
            foreach (var st in usos)
            {
                model.UsosList.Add(new SelectListItem { Value = st.uso_equipos, Text = st.nombre });
            }
            //llenar DropDownList de establecimientos
            var estab = datos.TraerEstablecimientos();
            foreach (var st in estab)
            {
                model.EstabList.Add(new SelectListItem { Value = st.cod_estab, Text = st.nombre });
            }
            //llenar DropDownList de odometro
            var odo = datos.TraerOdometro();
            foreach (var st in odo)
            {
                model.OdometroList.Add(new SelectListItem { Value = st.odometro, Text = st.nombre });
            }
            //llenar DropDownList de Colores
            var color = datos.TraerColores();
            foreach (var st in color)
            {
                model.ColorList.Add(new SelectListItem { Value = st.color, Text = st.nombre });
            }
            //llenar DropDownList de Frecuencia, vida util1, util2, garantia1, garantia2
            var fre = datos.TraerFrecuencias();
            foreach (var st in fre)
            {
                model.FrecuenciaList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre });
            }
            //llenar status
            model.status = "V";
            var sts = datos.TraerStatus();
            foreach (var st in sts)
            {
                model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

            }
            return model;
        }
        [HttpGet]
        public IActionResult NuevoEquipo()
        {
            return View(combos());
        }

        

        [HttpPost]
        public IActionResult NuevoEquipo(EquiposModelView model)
        {
            try
            {
                combos();
                var res = datos.GuardarEquipo(model, "N");
                if (res)
                {
                    return RedirectToAction("Equipos");
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

        [HttpGet]
        public IActionResult EditarEquipo(string id)
        {
            var model = new EquiposModelView();
            model = datos.TraerEquipo(id);
            //llenar DropDownList
            combos();
            return View(model);
        }


        //Equipos
        public IActionResult Equipos()
        {
            var model = new List<Equipos>();
            model = datos.TraerEquipos();
            return View(model);
           
          
        }
        ////guardar equipo
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult GuardarEquipo(EquiposModelView model)
        //{
            

        //}
        //lista de equipos kewydown
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
