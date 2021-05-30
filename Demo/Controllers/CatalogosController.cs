using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        public ServiciosModelView combosServ(string? id)
        {
            var model = new ServiciosModelView();
            var tipo = datos.TraerTiposServ();
            var conceptoS = datos.TraerConceptosS();
            var conceptoG = datos.TraerConceptosG();
            var sis = datos.TraerSistemaEquipos();
            model.status = "V";
            var sts = datos.TraerStatus();
            if (id != "")
            {
                model = datos.TraerServicio(id);
                if (model.status.Trim() == "V")
                {
                    model.status = "V";
                }
                if (model == null)
                {
                    TempData["mensajeINF"] = "No se encontró ningun servicio con ese ID";
                    RedirectToAction("Talleres");
                }
                foreach (var st in tipo)
                {
                    model.TipoServList.Add(new SelectListItem { Value = st.Tipo_servicio, Text = st.Nombre, Selected = st.Tipo_servicio.Trim() == model.tipo_servicio.Trim() });
                }
                foreach (var st in conceptoG)
                {
                    model.ConceptoGList.Add(new SelectListItem { Value = st.concepto_gastos, Text = st.nombre, Selected = st.concepto_gastos.Trim() == model.concepto_gastos.Trim() });
                }
                foreach (var st in conceptoS)
                {
                    model.ConceptoServList.Add(new SelectListItem { Value = st.concepto_servicio, Text = st.nombre, Selected = st.concepto_servicio.Trim() == model.concepto_servicio.Trim() });
                }
                foreach (var st in sis)
                {
                    model.SistemasList.Add(new SelectListItem { Value = st.sistema_equipos, Text = st.nombre, Selected = st.sistema_equipos.Trim() == model.sistema_equipos.Trim() });
                }
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre});

                }
            }
            else
            {
                foreach (var st in tipo)
                {
                    model.TipoServList.Add(new SelectListItem { Value = st.Tipo_servicio, Text = st.Nombre});
                }
                foreach (var st in conceptoG)
                {
                    model.ConceptoGList.Add(new SelectListItem { Value = st.concepto_gastos, Text = st.nombre});
                }
                foreach (var st in conceptoS)
                {
                    model.ConceptoServList.Add(new SelectListItem { Value = st.concepto_servicio, Text = st.nombre});
                }
                foreach (var st in sis)
                {
                    model.SistemasList.Add(new SelectListItem { Value = st.sistema_equipos, Text = st.nombre});
                }
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre});
                }
            }
            return model;
        }
        [HttpGet]
        public EquiposModelView combos(string? id)
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

            var vehi = datos.TraerTiposVehiculos();
            var chof = datos.TraerChofer();
            var carga = datos.TraerCargasEstandar();
            var ayudant = datos.TraerAyudantes();
            var comb = datos.TraerCombustibles();

            model.status = "V";
            var sts = datos.TraerStatus();
            if (id != "")
            {
                
                model = datos.TraerEquipo(id);
                if (model == null)
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

                foreach (var st in vehi)
                {
                    model.TipoVehicList.Add(new SelectListItem { Value = st.tipo_vehiculo, Text = st.nombre, Selected = model.tipo_vehiculo.Trim() == st.tipo_vehiculo });
                }
                foreach (var st in chof)
                {
                    model.ChoferList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.chofer.Trim()== st.chofer_ayudante });
                }
                foreach (var st in carga)
                {
                    model.CargaEstList.Add(new SelectListItem { Value = st.folio, Text = st.nombre,Selected = model.carga_estandar.Trim() == st.folio });
                }
                foreach (var st in ayudant)
                {
                    model.AyudanteList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre,Selected = model.ayudante.Trim() == st.chofer_ayudante });
                }
                foreach (var st in ayudant)
                {
                    model.AyudanteList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.ayudante2.Trim() == st.chofer_ayudante });
                }
                foreach (var st in comb)
                {
                    model.Tanque1List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa,Selected = model.combustible1.Trim()==st.cod_prod });
                }
                foreach (var st in comb)
                {
                    model.Tanque2List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible2.Trim() == st.cod_prod });
                }
                foreach (var st in comb)
                {
                    model.Tanque3List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible3.Trim() == st.cod_prod });
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
                //llenar DropDownList Tipovehiculo
                foreach (var st in vehi)
                {
                    model.TipoVehicList.Add(new SelectListItem { Value = st.tipo_vehiculo, Text = st.nombre });
                }
                //llenar DropDownList choferes
                foreach (var st in chof)
                {
                    model.ChoferList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre });
                }
                //llenar DropDownList carga estandar
                foreach (var st in carga)
                {
                    model.CargaEstList.Add(new SelectListItem { Value = st.folio, Text = st.nombre });
                }
                //llenar DropDownList ayudantes
                foreach (var st in ayudant)
                {
                    model.AyudanteList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre });
                }
                //llenar DropDownList combustible tanque
                foreach (var st in comb)
                {
                    model.Tanque1List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa });
                }

            }
            
            return model;
        }
        [HttpGet]
        public IActionResult NuevoEquipo()
        {
            return View(combos(""));
        }
        [HttpGet]
        public IActionResult NuevoServicio()
        {
            return View(combosServ(""));
        }
        public IActionResult Servicios()
        {
            var model = new List<Servicios>();
            model = datos.TraerServicios();
            return View(model);
        }
        [HttpGet]
        public IActionResult servicioDependiente()
        {
            List<ServicioDep> serv = new List<ServicioDep>();
            try
            {
                serv = datos.TraerServiciosDep();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_ServiciosDependientes", serv);
        }
        [HttpPost]
        public IActionResult NuevoServicioDependiente(ServicioDep model)
        {
            try
            {
                var res = datos.GuardarServicioDep(model, "N");
                if (res == true)
                {
                    TempData["mensajeSAVE"] = "Equipo guardado exitosamente";
                    return RedirectToAction("servicioDependiente");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Equipo";
                    return RedirectToAction("Servicios");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult NuevoServicio(ServiciosModelView model)
        {
            try
            {
                var res = datos.GuardarServicio(model, "N");
                if (res == true)
                {
                    TempData["mensajeSAVE"] = "Servicio guardado exitosamente";
                    return RedirectToAction("Servicios");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Servicio";
                    return RedirectToAction("Servicios");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }
        //editar servicio dependiente
        [HttpGet]
        public IActionResult EditarServicioDepende(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var serv = datos.TraerServicioDep(id);
            var model = new ServicioDep() { servicio = serv.servicio, nom_servicio = serv.nom_servicio, servicio_dependiente = serv.servicio_dependiente};
            return View(model);
        }
        //editar servicio
        [HttpGet]
        public IActionResult EditarServicio(string id)
        {
            if (id == null)
            {
                return BadRequest();
                
            }
            var model = combosServ(id);
            return View(model);
        }

        //editar servicio
        [HttpPost]
        public IActionResult EditarServicio(ServiciosModelView model)
        {
            try
            {
                
                var res = datos.GuardarServicio(model, "M");
                if (res == true)
                {
                    TempData["mensajeEDIT"] = "Servicio editado exitosamente";
                    return RedirectToAction("Servicios");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Servicio";
                    return RedirectToAction("Servicios");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
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

        [HttpGet]
        public IActionResult detalleActivos()
        {
            List<ActivosFiEquipos> detalle = new List<ActivosFiEquipos>();
            try
            {
                detalle = datos.TraerActivosFi();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_ActivosFijos", detalle);
        }
        [HttpGet]
        public IActionResult ServiciosDepende()
        {
            List<ServicioDep> detalle = new List<ServicioDep>();
            try
            {
                detalle = datos.TraerServiciosDep();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_DependenciaServicio", detalle);
        }
        [HttpGet]
        public IActionResult Areas()
        {
            List<AreasEquipos> detalle = new List<AreasEquipos>();
            try
            {
                detalle = datos.TraerAreas();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_Areas", detalle);
        }
        [HttpGet]
        public IActionResult Departamentos()
        {
            List<DepartamentosEquipos> detalle = new List<DepartamentosEquipos>();
            try
            {
                detalle = datos.TraerDepart();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_Departamentos", detalle);
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
