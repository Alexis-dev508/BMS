using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class CatalogosController : Controller
    {
        private IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private CatalogosData datos;
        public CatalogosController(IConfiguration configuration,IMemoryCache memoryCache)
        {
            _configuration = configuration;
            this.datos = new CatalogosData(_configuration);
            _cache = memoryCache;
        }
        //gastos de servicio
        public IActionResult AlimentacionGastosServicios()
        {
            var model = datos.TraerGS();
            return View(model);
        }
        //gastos de servicios a equipos
        [HttpGet]
        public IActionResult NuevoGastoServicios()
        {
            var model = new AlimentacionGSModelView();
            var estab = datos.TraerEstablecimientos();
            model.servicioGS.Add(new ServiciosGS() { id = 1 });

            foreach (var st in estab)
            {
                model.EstabList.Add(new SelectListItem { Value = st.cod_estab, Text = st.nombre});
            }
            return View(model);
        }
        //guardar gasto servicio
        [HttpPost]
        public IActionResult NuevoGastoServicios(AlimentacionGSModelView model)
        {
            try
            {
                //if(model.cod_prv == null)
                //{
                //    TempData["proveedor"] = "V";
                //    return View(model);
                //}
                var res = datos.GuardarGastosServicios(model);
                if (res == true)
                {
                    TempData["mensajeSAVE"] = "Guardado exitosamente";
                    return RedirectToAction("AlimentacionGastosServicios");
                }
                else
                {
                    TempData["mensajeINF"] = "Ha ocurrido un error.";
                    return RedirectToAction("AlimentacionGastosServicios");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult modeloNuevoEquipo(string id)
        {
            var Mod = datos.TraerModelos(id);
            if (Mod.Count <= 0)
            {
                ViewBag.ModelCount = 0;
                return PartialView("ModelList");
            }
            ViewBag.ModelList = new SelectList(Mod, "modelo_equipos", "nombre");
            return PartialView("ModelList");
        }
        //COMBOS MARCA.MODELO,VERSION
        public IActionResult modelo(string id)
        {
            var Mod = datos.TraerModelos(id);
            if (_cache.Get("equipo").ToString() != null)
            {
                Equipos e = new Equipos();
                e = datos.TraerEquipo(_cache.Get("equipo").ToString());
                ModelosEquipos mo = new ModelosEquipos();
                mo = datos.TraermodeloCombo(e.modelo.ToString().Trim());
                if (mo != null)
                {
                    ViewBag.modelo = e.modelo;
                    ViewBag.nombremodelo = mo.nombre.ToString();
                }
                else
                {
                    ViewBag.modelo = null;
                    ViewBag.nombremodelo = null;
                }
               
            }
            
            if (Mod.Count <= 0)
            {
                ViewBag.ModelCount = 0;
                return PartialView("ModelList");
            }
            ViewBag.ModelList = new SelectList(Mod, "modelo_equipos", "nombre");
            return PartialView("ModelList");
        }
        public IActionResult version(string id)
        {
            var Mod = datos.TraerVersiones(id);
            if (_cache.Get("equipo").ToString() != null)
            {
                Equipos e = new Equipos();
                var eq = _cache.Get("equipo").ToString();
                e = datos.TraerEquipo(eq);
                var version = e.version.ToString().Trim();
                VersionesEquipos ve = new VersionesEquipos();
                ve = datos.TraerversionCombo(version);
                
                if(ve != null)
                {
                    ViewBag.version = e.version;
                    ViewBag.nombreversion = ve.nombre.ToString();
                }
                else
                {
                    ViewBag.version = null;
                    ViewBag.nombreversion = null;
                }
                
            }
            if (Mod.Count <= 0)
            {
                ViewBag.VersionCount = 0;
                return PartialView("VersionList");
            }
            ViewBag.VersionList = new SelectList(Mod, "version_equipos", "nombre");
            return PartialView("VersionList");
        }
        public IActionResult versionNuevoEquipo(string id)
        {
            var Mod = datos.TraerVersiones(id);
            if (Mod.Count <= 0)
            {
                ViewBag.VersionCount = 0;
                return PartialView("VersionList");
            }
            ViewBag.VersionList = new SelectList(Mod, "version_equipos", "nombre");
            return PartialView("VersionList");
        }
        //combos de Taller/Servicios
        [HttpGet]
        public ServiciosModelView combosServ(string id)
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
        //combos Equipos/Equipos
        [HttpGet]
        public EquiposModelView combos(string id)
        {
            var model = new EquiposModelView();
            var marc = datos.TraerMarcas();
            var vers = datos.TraerVersiones("");
            var mode = datos.TraerModelos("");
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
                    if (model.marca == null || model.marca.Trim() == "")
                    {
                        model.MarcasList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.MarcasList.Add(new SelectListItem { Value = st.marca_equipo, Text = st.nombre, Selected = st.marca_equipo.Trim() == model.marca.Trim()  });
                }
                foreach (var st in vers)
                {
                    if (model.version.Trim() == null || model.version.Trim() == "")
                    {
                        model.VersionList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.VersionList.Add(new SelectListItem { Value = st.version_equipos, Text = st.nombre, Selected = model.version.Trim() == st.version_equipos.Trim() });

                }
                foreach (var st in mode)
                {
                    if (model.modelo.Trim() == null|| model.modelo.Trim()=="")
                    {
                        model.ModelosList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.ModelosList.Add(new SelectListItem { Value = st.modelo_equipos, Text = st.nombre, Selected = model.modelo.Trim() == st.modelo_equipos.Trim() });

                }
                foreach (var st in annios)
                {
                    if (model.año.Trim() == null || model.año.Trim() == "")
                    {
                        model.AnniosList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.AnniosList.Add(new SelectListItem { Value = st.año_equipos, Text = st.año_equipos, Selected = model.año.Trim() == st.año_equipos.Trim() });
                }
                foreach (var st in tipoE)
                {
                    if (model.tipo_equipo.Trim() == null || model.tipo_equipo.Trim() == "")
                    {
                        model.TipoEquipoList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.TipoEquipoList.Add(new SelectListItem { Value = st.tipo_equipo, Text = st.nombre, Selected = model.tipo_equipo.Trim() == st.tipo_equipo.Trim() });
                }
                foreach (var st in usos)
                {
                    if (model.uso_equipos.Trim() == null || model.uso_equipos.Trim() == "")
                    {
                        model.UsosList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.UsosList.Add(new SelectListItem { Value = st.uso_equipos, Text = st.nombre, Selected = model.uso_equipos.Trim() == st.uso_equipos.Trim() });
                }
                foreach (var st in estab)
                {
                    if (model.cod_estab.Trim() == null || model.cod_estab.Trim() == "")
                    {
                        model.EstabList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.EstabList.Add(new SelectListItem { Value = st.cod_estab, Text = st.nombre, Selected = model.cod_estab.Trim() == st.cod_estab.Trim() });
                }
                foreach (var st in color)
                {
                    if (model.color.Trim() == null || model.color.Trim() == "")
                    {
                        model.ColorList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.ColorList.Add(new SelectListItem { Value = st.color, Text = st.nombre, Selected = model.color.Trim() == st.color.Trim() });
                }
                foreach (var st in fre)
                {
                    if (model.medida_garantia.Trim() == null || model.medida_garantia.Trim() == "")
                    {
                        model.MedidaGarantiaList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.MedidaGarantiaList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_garantia.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    if (model.medida_garantia2.Trim() == null || model.medida_garantia2.Trim() == "")
                    {
                        model.MedidaGarantia2List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.MedidaGarantia2List.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_garantia2.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    if (model.medida_vida_util.Trim() == null || model.medida_vida_util.Trim() == "")
                    {
                        model.MedidaVidaUtilList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.MedidaVidaUtilList.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_vida_util.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in fre)
                {
                    if (model.medida_vida_util2.Trim() == null || model.medida_vida_util2.Trim() == "")
                    {
                        model.MedidaVidaUtil2List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.MedidaVidaUtil2List.Add(new SelectListItem { Value = st.frecuencia_servicio_equipos, Text = st.nombre, Selected = model.medida_vida_util2.Trim() == st.frecuencia_servicio_equipos.Trim() });
                }
                foreach (var st in sts)
                {
                    model.StatusList.Add(new SelectListItem { Value = st.status, Text = st.nombre, Selected = model.status.Trim() == st.status });

                }
                foreach (var st in odo)
                {
                    if (model.odometro.Trim() == null || model.odometro.Trim() == "")
                    {
                        model.OdometroList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.OdometroList.Add(new SelectListItem { Value = st.odometro, Text = st.nombre,Selected = model.odometro.Trim() == st.odometro });
                }

                foreach (var st in vehi)
                {
                    if (model.tipo_vehiculo.Trim() == null || model.tipo_vehiculo.Trim() == "")
                    {
                        model.TipoVehicList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.TipoVehicList.Add(new SelectListItem { Value = st.tipo_vehiculo, Text = st.nombre, Selected = model.tipo_vehiculo.Trim() == st.tipo_vehiculo });
                }
                foreach (var st in chof)
                {
                    if (model.chofer.Trim() == null || model.chofer.Trim() == "")
                    {
                        model.ChoferList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.ChoferList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.chofer.Trim()== st.chofer_ayudante });
                }
                foreach (var st in carga)
                {
                    if (model.carga_estandar.Trim() == null || model.carga_estandar.Trim() == "")
                    {
                        model.CargaEstList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT", Selected = true });
                    }
                    model.CargaEstList.Add(new SelectListItem { Value = st.folio, Text = st.nombre,Selected = model.carga_estandar.Trim() == st.folio });
                }
                
                model.Ayudante2List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                if(model.ayudante.Trim() ==null || model.ayudante.Trim() == "")
                {
                    model.AyudanteList.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                    model.ayudante = "DEFAULT";
                    foreach (var st in ayudant)
                    {
                        model.AyudanteList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.ayudante.Trim() == st.chofer_ayudante });
                    }
                }
                else
                {
                    foreach (var st in ayudant)
                    {
                        model.AyudanteList.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.ayudante.Trim() == st.chofer_ayudante });
                    }
                }
                if (model.ayudante2.Trim() == null || model.ayudante2.Trim() == "")
                {
                    model.Ayudante2List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                    model.ayudante2 = "DEAFULT";
                    foreach (var st in ayudant)
                    {
                        model.Ayudante2List.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.ayudante2.Trim() == st.chofer_ayudante });
                    }
                }
                else
                {
                    foreach (var st in ayudant)
                    {
                        model.Ayudante2List.Add(new SelectListItem { Value = st.chofer_ayudante, Text = st.nombre, Selected = model.ayudante2.Trim() == st.chofer_ayudante });
                    }
                }
                
                if (model.combustible2.Trim() == null || model.combustible2.Trim() == "")
                {
                    model.Tanque2List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                    model.combustible2 = "DEFAULT";
                    foreach (var st in comb)
                    {
                        model.Tanque2List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible2.Trim() == st.cod_prod });
                    }
                }
                else
                {
                    foreach (var st in comb)
                    {
                        model.Tanque2List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible2.Trim() == st.cod_prod });
                    }
                }
                if (model.combustible1.Trim() == null || model.combustible1.Trim() == "")
                {
                    model.Tanque1List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                    model.combustible1 = "DEFAULT";
                    foreach (var st in comb)
                    {
                        model.Tanque1List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible1.Trim() == st.cod_prod });
                    }
                }
                else
                {
                    foreach (var st in comb)
                    {
                        model.Tanque1List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible1.Trim() == st.cod_prod });
                    }
                }
                if (model.combustible3.Trim() == null || model.combustible3.Trim() == "")
                {
                    model.Tanque3List.Add(new SelectListItem { Text = "No aplica", Value = "DEFAULT" });
                    model.combustible3 = "DEFAULT";
                    foreach (var st in comb)
                    {
                        model.Tanque3List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible3 == st.cod_prod });
                    }
                }
                else
                {
                    foreach (var st in comb)
                    {
                        model.Tanque3List.Add(new SelectListItem { Value = st.cod_prod, Text = st.descripcion_completa, Selected = model.combustible3.Trim() == st.cod_prod });
                    }
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
        //vista de Nuevo equipo
        [HttpGet]
        public IActionResult NuevoEquipo()
        {
            //llenar combos
            return View(combos(""));
        }
        //vista Nuevo servicio dependiente
        [HttpGet]
        public IActionResult NuevoServicioDependiente()
        {
            return View();
        }
        //vista nuevo servicio
        [HttpGet]
        public IActionResult NuevoServicio()
        {
            return View(combosServ(""));
        }
        //vista de Servicios
        public IActionResult Servicios()
        {
            var model = new List<Servicios>();
            model = datos.TraerServicios();
            return View(model);
        }
        //vista de servicios dependientes
        [HttpGet]
        public IActionResult ServiciosDep()
        {
            var model = new List<ServicioDep>();
            model = datos.TraerServiciosDep();
            return View(model);
        }
        

        //Guardar servicio dependiente
        [HttpPost]
        public IActionResult NuevoServicioDependiente(ServicioDep model)
        {
            try
            {
                var res = datos.GuardarServicioDep(model, "N");
                if (res == true)
                {
                    TempData["mensajeSAVE"] = "Servicio dependiente guardado exitosamente";
                    return RedirectToAction("ServiciosDep");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar servicio";
                    return RedirectToAction("ServiciosDep");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }
        //eliminar servicio dependiente
        [HttpPost]
        public IActionResult EliminarServicioDependiente(ServicioDep model)
        {
            try
            {
                //metodo de guardar pero operacion Eliminar (E)
                var res = datos.GuardarServicioDep(model, "E");
                if (res == true)
                {
                    TempData["mensajeDEL"] = "Servicio Eliminado exitosamente";
                    return RedirectToAction("ServiciosDep");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar servicio";
                    return RedirectToAction("ServiciosDep");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Errores = ex.Message;
                return View(model);
            }
        }
        //guardar servicio
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
        [HttpPost]
        public IActionResult EditarServicioDependiente(ServicioDep model)
        {
            try
            {
                var serv = datos.GuardarServicioDep(model, "M");
                if (serv)
                {
                    TempData["mensajeSAVE"] = "Servicio guardado exitosamente";
                    return RedirectToAction("ServiciosDep");
                }
                else
                {
                    TempData["mensajeINF"] = "Error al guardar Servicio";
                    return RedirectToAction("ServiciosDep");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Errores = ex.Message;
                return View(model);
            }
            
        }
        //editar servicio dependiente Vista
        [HttpGet]
        public IActionResult detalleEdit()
        {
            return PartialView("_edit",null);
        }
        //eliminar servicio dependiente vista
        [HttpGet]
        public IActionResult detalleDelete()
        {
            return PartialView("_delete", null);
        }
        //editar servicio Vista
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

        //editar servicio Guardar
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
        //guardar equipo
        [HttpPost]
        public IActionResult NuevoEquipo(EquiposModelView model)
        {
            try
            {
                //validarEquipo(model);
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
        //traer datos de equipo para editar (Vista)
        [HttpGet]
        public IActionResult EditarEquipos(string id)
        {
            MemoryCacheEntryOptions cacheExpirationOption = new MemoryCacheEntryOptions();
            cacheExpirationOption.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            cacheExpirationOption.Priority = CacheItemPriority.Normal;
            _cache.Set("equipo", id,cacheExpirationOption);
            if (id == null)
            {
                return BadRequest();
            }
            return View(combos(id));
        }
        //Guardar equipo editado
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
                model = combos("");
                return View(model);
            }
        }
        //Vista de activos fijos
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
        //vista de equipos depende
        [HttpGet]
        public IActionResult EquipoDepende()
        {
            List<Equipos> detalle = new List<Equipos>();
            try
            {
                detalle = datos.TraerEquipos("");
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_DependeEquipo", detalle);
        }
        //traer equipo gasto servicio
        [HttpGet]
        public IActionResult EquipoGastoServicio()
        {
            List<Equipos> detalle = new List<Equipos>();
            try
            {
                detalle = datos.TraerEquipos("GS");
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_EquipoGS", detalle);
        }
        //traer proveedor
        [HttpGet]
        public IActionResult Proveedor()
        {
            List<Proveedores> detalle = new List<Proveedores>();
            try
            {
                detalle = datos.TraerProveedores();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_Proveedores",detalle);
        }
        //folio gastos servicios
        public IActionResult FolioGastoServicio(string id)
        {
            AlimentacionGSModelView fol = new AlimentacionGSModelView();
            fol = datos.TraerFolio(id);
            if (fol.folio.Trim() == "Error")
            {
                return PartialView("_FolioGS"); ;
            }
            ViewBag.folio = fol.folio.Trim();
            return PartialView("_FolioGS");
        }
        //vista de servicios depende
        [HttpGet]
        public IActionResult ServiciosDepende()
        {
            List<Servicios> detalle = new List<Servicios>();
            try
            {
                detalle = datos.TraerServicios();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_ServiciosDep", detalle);
        }
        //vista de servicios F2
        [HttpGet]
        public IActionResult Serv()
        {
            List<Servicios> detalle = new List<Servicios>();
            try
            {
                detalle = datos.TraerServicios();
            }
            catch (Exception ex)
            {

                ViewBag.ErroresM = ex.Message;
            }
            return PartialView("_Servicios", detalle);
        }
        //vista de areas F2
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
        //vista de servicio depenede
        //[HttpGet]
        //public IActionResult Dependencias()
        //{
        //    List<Servicios> detalle = new List<Servicios>();
        //    try
        //    {
        //        detalle = datos.TraerServicios();
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.ErroresM = ex.Message;
        //    }
        //    return PartialView("_ServiciosDep", detalle);
        //}

        //vista de departamentos F2 
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
        //Equipos Vista
        public IActionResult Equipos()
        {
            var model = new List<Equipos>();
            model = datos.TraerEquipos("");
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
        //public EquiposModelView validarEquipo(EquiposModelView model)
        //{
        //    if (model.nombre == null)
        //    {
        //        if (model.abreviatura == null)
        //        {
        //            TempData["mensajeNULL"] = "La abreviatura es obligatoria";
        //            combos("");
        //        }
        //        TempData["mensajeNULL"] = "El nombre es obligatorio";
        //        combos("");
        //    }
        //    return model;
        //}
    }
}
