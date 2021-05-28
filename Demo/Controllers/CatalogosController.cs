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
        public EquiposModelView combos(string? id, string oper = null)
        {
            var model = new EquiposModelView();
            var marc = datos.TraerMarcas();
            var vers = datos.TraerVersiones();
            var mode = datos.TraerModelos();
            var annios = datos.TraerAnnios();
            var tipoE = datos.TraerTipoEquipo();
            var usos = datos.TraerUsos();
            var estab = datos.TraerEstablecimientos();
            var color = datos.TraerColores();
            var fre = datos.TraerFrecuencias();
            var odo = datos.TraerOdometro();
            model.status = "V";
            var sts = datos.TraerStatus();
            if (id != "")
            {
                model = datos.TraerEquipo(id);
                if(model == null)
                {
                    TempData["mensajeINF"] = "No se encontró ningun equipo con ese ID";
                    RedirectToAction("Equipos");
                }
                foreach (var st in marc)
                {
                    model.MarcasList.Add(new SelectListItem { Value = st.marca_equipo, Text = st.nombre, Selected = st.marca_equipo.Trim() == model.marca.Trim()  });
                }
                foreach (var st in vers)
                {
                    model.VersionList.Add(new SelectListItem { Value = st.version_equipos, Text = st.nombre, Selected = model.version.Trim() == st.version_equipos.Trim() });

                }
                foreach (var st in mode)
                {
                    model.ModelosList.Add(new SelectListItem { Value = st.modelo_equipos, Text = st.nombre, Selected = model.modelo.Trim() == st.modelo_equipos.Trim() });

                }
                foreach (var st in annios)
                {
                    model.AnniosList.Add(new SelectListItem { Value = st.año_equipos, Text = st.año_equipos, Selected = model.año.Trim() == st.año_equipos.Trim() });
                }
                foreach (var st in tipoE)
                {
                    model.TipoEquipoList.Add(new SelectListItem { Value = st.tipo_equipo, Text = st.nombre, Selected = model.tipo_equipo.Trim() == st.tipo_equipo.Trim() });
                }
                foreach (var st in usos)
                {
                    model.UsosList.Add(new SelectListItem { Value = st.uso_equipos, Text = st.nombre, Selected = model.uso_equipos.Trim() == st.uso_equipos.Trim() });
                }
                foreach (var st in estab)
                {
                    model.EstabList.Add(new SelectListItem { Value = st.cod_estab, Text = st.nombre, Selected = model.cod_estab.Trim() == st.cod_estab.Trim() });
                }
                foreach (var st in color)
                {
                    model.ColorList.Add(new SelectListItem { Value = st.color, Text = st.nombre, Selected = model.color.Trim() == st.color.Trim() });
                }
                foreach (var st in fre)
                {
                    model.MedidaGarantiaList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_garantia.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    model.MedidaGarantia2List.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_garantia2.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    model.MedidaVidaUtilList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_vida_util.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    model.MedidaVidaUtil2List.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_vida_util2.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                foreach (var st in odo)
                {
                    model.OdometroList.Add(new SelectListItem { Value = st.odometro, Text = st.nombre });
                }
            }
            else
            {
                //llenar DropDownList de marcas
                foreach (var st in marc)
                {
                    model.MarcasList.Add(new SelectListItem { Value = st.marca_equipo, Text = st.nombre });

                }
                //llenar DropDownList de versiones

                foreach (var st in vers)
                {
                    model.VersionList.Add(new SelectListItem { Value = st.version_equipos, Text = st.nombre });

                }
                //llenar DropDownList de modelos

                foreach (var st in mode)
                {
                    model.ModelosList.Add(new SelectListItem { Value = st.modelo_equipos, Text = st.nombre });

                }
                //llenar DropDownList de años

                foreach (var st in annios)
                {
                    model.AnniosList.Add(new SelectListItem { Value = st.año_equipos, Text = st.año_equipos });
                }
                //llenar DropDownList de tipo Equipo

                foreach (var st in tipoE)
                {
                    model.TipoEquipoList.Add(new SelectListItem { Value = st.tipo_equipo, Text = st.nombre });
                }
                //llenar DropDownList de usos

                foreach (var st in usos)
                {
                    model.UsosList.Add(new SelectListItem { Value = st.uso_equipos, Text = st.nombre });
                }
                //llenar DropDownList de establecimientos

                foreach (var st in estab)
                {
                    model.EstabList.Add(new SelectListItem { Value = st.cod_estab, Text = st.nombre });
                }
                //llenar DropDownList de odometro

                foreach (var st in odo)
                {
                    model.OdometroList.Add(new SelectListItem { Value = st.odometro, Text = st.nombre });
                }
                //llenar DropDownList de Colores

                foreach (var st in color)
                {
                    model.ColorList.Add(new SelectListItem { Value = st.color, Text = st.nombre });
                }
                //llenar DropDownList de Frecuencia, vida util1, util2, garantia1, garantia2

                foreach (var st in fre)
                {
                    model.FrecuenciaList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre });
                }
                //llenar status

                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
            }
            
            return model;
        }
        [HttpGet]
        public IActionResult NuevoEquipo()
        {
            return View(combos(""));
        }
        public IActionResult DetallesAdicionalesEquipos()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult NuevoEquipo(EquiposModelView model)
        {
            try
            {
                var res = datos.GuardarEquipo(model, "N");
                if (res == true)
                {
                    TempData["mensajeSAVE"] = "Equipo guardado exitosamente";
                    return RedirectToAction("Equipos");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Equipo";
                    return RedirectToAction("Equipos");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult EditarEquipos(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View(combos(id));
        }
        [HttpPost]
        public IActionResult EditarEquipos(EquiposModelView model)
        {
            try
            {
                var res = datos.GuardarEquipo(model, "M");
                if (res == true)
                {
                    TempData["mensajeEDIT"] = "Equipo editado exitosamente";
                    return RedirectToAction("Equipos");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Equipo";
                    return RedirectToAction("Equipos");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
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
