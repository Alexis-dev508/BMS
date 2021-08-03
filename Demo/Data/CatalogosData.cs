using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo.Data
{
    public class CatalogosData
    {
        private string ConnectionString;

        private readonly IConfiguration _configuration;

        public CatalogosData(IConfiguration configuration)
        {
            _configuration = configuration;
            this.ConnectionString = _configuration.GetConnectionString("BMS");
        }
        public List<Aromas> TraerAromas()
        {
            List<Aromas> aromas = new List<Aromas>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Aromas",this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Operacion", "R");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            aromas = dt.AsEnumerable().Select(a =>
            new Aromas {
                aroma = a["aroma"].ToString(),
                nombre = a["nombre"].ToString(),
                abreviatura = a["abreviatura"].ToString(),
                status = a["status"].ToString()
            }).ToList();
            //foreach (var reg in dt.Rows)
            //{
            //    aromas.Add(new Aromas { aroma = reg["aroma"].ToString() }).Tolist();
            //}

            return aromas;
        }
        //traer marcas
        public List<MarcasEquipos> TraerMarcas()
        {
            List<MarcasEquipos> marcas = new List<MarcasEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "MA");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            marcas = dt.AsEnumerable().Select(a =>
            new MarcasEquipos
            {
                marca_equipo = a["marca_equipos"].ToString(),
                nombre = a["nombre"].ToString()
            }).ToList();
            return marcas;
        }
        //traer modelo para combo editar
        public ModelosEquipos TraermodeloCombo(string m)
        {
            ModelosEquipos mode = new ModelosEquipos();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "MO");
                sda.SelectCommand.Parameters.AddWithValue("@modelo", m);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                mode = dt.AsEnumerable().Select(a =>
                new ModelosEquipos
                {
                   modelo_equipos = a["modelo_equipos"].ToString(),
                    nombre =a["nombre"].ToString()
                }).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return mode;
        }
        //traer version para combo editar
        public VersionesEquipos TraerversionCombo(string m)
        {
            VersionesEquipos ve = new VersionesEquipos();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "VE");
                sda.SelectCommand.Parameters.AddWithValue("@version", m);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ve = dt.AsEnumerable().Select(a =>
                new VersionesEquipos
                {
                    version_equipos = a["version_equipos"].ToString(),
                    nombre = a["nombre"].ToString()
                }).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ve;
        }
        //tarer modelos
        public List<ModelosEquipos> TraerModelos(string id)
        {
            List<ModelosEquipos> modelos = new List<ModelosEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "MO");
                sda.SelectCommand.Parameters.AddWithValue("@marca", id);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                modelos = dt.AsEnumerable().Select(a =>
                new ModelosEquipos
                {
                    marca_equipos = a["marca_equipos"].ToString(),
                    modelo_equipos = a["modelo_equipos"].ToString(),
                    nombre = a["nombre"].ToString()
                }).ToList();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return modelos;
        }
        //traer versiones
        public List<VersionesEquipos> TraerVersiones(string id)
        {
            List<VersionesEquipos> versiones = new List<VersionesEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "VE");
            sda.SelectCommand.Parameters.AddWithValue("@modelo", id);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            versiones = dt.AsEnumerable().Select(a =>
            new VersionesEquipos
            {
                version_equipos = a["version_equipos"].ToString(),
                nombre = a["nombre"].ToString(),
                modelo_equipos = a["modelo_equipos"].ToString(),
                marca_equipos = a["marca_equipos"].ToString()

            }).ToList();
            return versiones;
        }
        //traer años
        public List<AnniosEquipos> TraerAnnios()
        {
            List<AnniosEquipos> annios = new List<AnniosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "AN");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            annios = dt.AsEnumerable().Select(a =>
            new AnniosEquipos
            {
                año_equipos=a["año_equipos"].ToString()

            }).ToList();
            return annios;
        }


        //traer tipo equipos
        public List<TiposEquipos> TraerTipoEquipo()
        {
            List<TiposEquipos> tiposE = new List<TiposEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "TE");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tiposE = dt.AsEnumerable().Select(a =>
            new TiposEquipos
            {
                tipo_equipo = a["tipo_equipo"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return tiposE;
        }
        //traer usos
        public List<UsosEquipos> TraerUsos()
        {
            List<UsosEquipos> usos = new List<UsosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "US");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            usos = dt.AsEnumerable().Select(a =>
            new UsosEquipos
            {
                uso_equipos = a["uso_equipos"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return usos;
        }
        //traer establecimientos
        public List<EstablecimientosEquipos> TraerEstablecimientos()
        {
            List<EstablecimientosEquipos> establecimientos = new List<EstablecimientosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "ES");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            establecimientos = dt.AsEnumerable().Select(a =>
            new EstablecimientosEquipos
            {
                cod_estab = a["cod_estab"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return establecimientos;
        }
        //traer odometro
        public List<OdometrosEquipos> TraerOdometro()
        {
            List<OdometrosEquipos> odometros = new List<OdometrosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "OD");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            odometros = dt.AsEnumerable().Select(a =>
            new OdometrosEquipos
            {
                odometro = a["odometro"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return odometros;
        }
        //traer colores
        public List<ColoresEquipos> TraerColores()
        {
            List<ColoresEquipos> colores = new List<ColoresEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "CO");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            colores = dt.AsEnumerable().Select(a =>
            new ColoresEquipos
            {
                color = a["color"].ToString(),
                nombre = a["nombre"].ToString(),
                status = a["status"].ToString()

            }).ToList();
            return colores;
        }
        //traer frecuencias
        public List<FrecuenciasEquipos> TraerFrecuencias()
        {
            List<FrecuenciasEquipos> frecuencias = new List<FrecuenciasEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "FR");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            frecuencias = dt.AsEnumerable().Select(a =>
            new FrecuenciasEquipos
            {
                frecuencia_servicio_equipos = a["frecuencia_servicio_equipos"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return frecuencias;
        }
        //traer areas
        public List<AreasEquipos> TraerAreas()
        {
            List<AreasEquipos> areas = new List<AreasEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "AR");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                areas = dt.AsEnumerable().Select(a =>
                new AreasEquipos
                {
                    area = a["area"].ToString(),
                    nombre = a["nombre"].ToString(),
                    abreviatura = a["abreviatura"].ToString(),
                    status = a["status"].ToString(),

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return areas;
        }
        //traer departamento
        public List<DepartamentosEquipos> TraerDepart()
        {
            List<DepartamentosEquipos> departamentos = new List<DepartamentosEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "DT");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                departamentos = dt.AsEnumerable().Select(a =>
                new DepartamentosEquipos
                {
                    departamento = a["departamento"].ToString(),
                    nombre = a["nombre"].ToString(),
                    abreviatura = a["abreviatura"].ToString(),
                    status = a["status"].ToString(),

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return departamentos;
        }
        //traer activos fijos
        public List<ActivosFiEquipos> TraerActivosFi()
        {
            List<ActivosFiEquipos> activosFi = new List<ActivosFiEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "AF");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                activosFi = dt.AsEnumerable().Select(a =>
                new ActivosFiEquipos
                {
                    activo_fijo = a["activo_fijo"].ToString(),
                    fecha = Convert.ToDateTime(a["fecha"]),
                    descripcion = a["descripcion"].ToString(),
                    marca = a["marca"].ToString(),
                    modelo = a["modelo"].ToString(),
                    talla = a["talla"].ToString(),
                    color = a["color"].ToString(),
                    serie = a["serie"].ToString(),
                    motor = a["motor"].ToString(),
                    tipo_activo_fijo = a["tipo_activo_fijo"].ToString(),
                    transaccion = a["transaccion"].ToString(),
                    cod_estab = a["cod_estab"].ToString(),
                    ubicacion = a["ubicacion"].ToString(),
                    fecha_adquisicion = Convert.ToDateTime(a["fecha_adquisicion"]),
                    monto_original_inversion = Convert.ToDecimal(a["monto_original_inversion"]),
                    usuario = a["usuario"].ToString(),
                    usuario_baja = a["usuario_baja"].ToString(),
                    fecha_baja = Convert.ToDateTime(a["fecha_baja"]),
                    status = a["status"].ToString(),
                    empleado = a["empleado"].ToString(),

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return activosFi;
        }
        //traer tipo vehiculo
        public List<TiposVeEquipos> TraerTiposVehiculos()
        {
            List<TiposVeEquipos> tiposVe = new List<TiposVeEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "TV");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                tiposVe = dt.AsEnumerable().Select(a =>
                new TiposVeEquipos
                {
                    tipo_vehiculo = a["tipo_vehiculo"].ToString(),
                    nombre = a["nombre"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return tiposVe;
        }
        //traer chofer
        public List<ChoferEquipos> TraerChofer()
        {
            List<ChoferEquipos> chofer = new List<ChoferEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "CH");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chofer = dt.AsEnumerable().Select(a =>
            new ChoferEquipos
            {
                chofer_ayudante = a["chofer_ayudante"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return chofer;
        }
        //traer empleados
        public List<EmpleadosEquipos> TraerEmpleados()
        {
            List<EmpleadosEquipos> empleados = new List<EmpleadosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "EM");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            empleados = dt.AsEnumerable().Select(a =>
            new EmpleadosEquipos
            {
                empleado = a["empleado"].ToString(),
                nombre_completo = a["nombre_completo"].ToString()

            }).ToList();
            return empleados;
        }
        //traer cargas estandar
        public List<CargasEstEquipos> TraerCargasEstandar()
        {
            List<CargasEstEquipos> cargasEst = new List<CargasEstEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "CE");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cargasEst = dt.AsEnumerable().Select(a =>
            new CargasEstEquipos
            {
                folio = a["folio"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return cargasEst;
        }
        //traer accesorios (Este metodo no se ha usado)
        public List<AccesoriosEquipos> TraerAccesorios()
        {
            List<AccesoriosEquipos> accesorios = new List<AccesoriosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "AC");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            accesorios = dt.AsEnumerable().Select(a =>
            new AccesoriosEquipos
            {
                equipo = a["equipo"].ToString(),
                accesorio = a["accesorio"].ToString(),
                cantidad = Convert.ToDecimal(a["cantidad"]),
                valor = Convert.ToDecimal(a["valor"]),
                fecha = Convert.ToDateTime(a["fecha"]),
                nombre = a["nombre"].ToString(),
                Tipo_equipo = a["Tipo_equipo"].ToString()

            }).ToList();
            return accesorios;
        }
        //traer combustibles
        public List<CombustiblesEquipos> TraerCombustibles()
        {
            List<CombustiblesEquipos> combustibles = new List<CombustiblesEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "CM");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            combustibles = dt.AsEnumerable().Select(a =>
            new CombustiblesEquipos
            {
                cod_prod = a["cod_prod"].ToString(),
                descripcion_completa = a["descripcion_completa"].ToString()

            }).ToList();
            return combustibles;
        }
        //traer ayudantes
        public List<AyudantesEquipos> TraerAyudantes()
        {
            List<AyudantesEquipos> ayudantes = new List<AyudantesEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "AY");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ayudantes = dt.AsEnumerable().Select(a =>
            new AyudantesEquipos
            {
                chofer_ayudante = a["chofer_ayudante"].ToString(),
                nombre = a["nombre"].ToString()

            }).ToList();
            return ayudantes;
        }
        //folios
        public AlimentacionGSModelView TraerFolio(string id)
        {
            AlimentacionGSModelView GS = new AlimentacionGSModelView();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                sda.SelectCommand.Parameters.AddWithValue("@oper", "F");
                sda.SelectCommand.Parameters.AddWithValue("@cod_estab", id);
                
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GS = dt.AsEnumerable().Select(a =>
                new AlimentacionGSModelView
                {
                    folio = a["folio"].ToString()
                }).SingleOrDefault();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return GS;
        }
        //facturas
        public AlimentacionGSModelView TraerFactura(string estab,string factura)
        {
            AlimentacionGSModelView GS = new AlimentacionGSModelView();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                sda.SelectCommand.Parameters.AddWithValue("@folio_propio", "");
                sda.SelectCommand.Parameters.AddWithValue("@oper", "A");
                sda.SelectCommand.Parameters.AddWithValue("@factura_proveedor", factura);
                sda.SelectCommand.Parameters.AddWithValue("@cod_estab", estab);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                GS = dt.AsEnumerable().Select(a =>
                new AlimentacionGSModelView
                {
                    folio_propio = a["folio_propio"].ToString()
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return GS;
        }
        //consultar concepto de gasto
        public AlimentacionGSModelView consultarConcepto(string servicio)
        {
            AlimentacionGSModelView GS = new AlimentacionGSModelView();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                sda.SelectCommand.Parameters.AddWithValue("@servicio", servicio);
                sda.SelectCommand.Parameters.AddWithValue("@oper", "B");

                DataTable dt = new DataTable();
                sda.Fill(dt);
                GS = dt.AsEnumerable().Select(a =>
                new AlimentacionGSModelView
                {
                    servicio = a["servicio"].ToString()
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return GS;
        }
        //consultar iva de concepto
        public AlimentacionGSModelView traerIva(string concepto)
        {
            AlimentacionGSModelView GS = new AlimentacionGSModelView();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                sda.SelectCommand.Parameters.AddWithValue("@concepto", concepto);
                sda.SelectCommand.Parameters.AddWithValue("@oper", "D");

                DataTable dt = new DataTable();
                sda.Fill(dt);
                GS = dt.AsEnumerable().Select(a =>
                new AlimentacionGSModelView
                {
                    IVA = Convert.ToDecimal(a["iva"])
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return GS;
        }
        //traer informacion de equipos
        public List<Equipos> TraerEquipos(string oper)
        {
            List<Equipos> equipos = new List<Equipos>();
            if(oper == "GS" || oper !="")
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Equipos", this.ConnectionString);
                    sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@oper", "G");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    equipos = dt.AsEnumerable().Select(a =>
                    new Equipos
                    {
                        equipo = a["equipo"].ToString(),
                        nombre = a["nombre"].ToString(),
                        marca = a["marca"].ToString(),
                        modelo = a["modelo"].ToString(),
                        año = a["año"].ToString(),
                        serie = a["serie"].ToString(),
                        motor = a["motor"].ToString().Trim(),
                        placas = a["placas"].ToString(),
                        ultima_lectura = Convert.ToInt64(a["ultima_lectura"]),
                        chofer = a["chofer"].ToString(),
                        Nombre_Chofer = a["NombreCh"].ToString(),
                    }).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "R");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                equipos = dt.AsEnumerable().Select(a =>
                new Equipos
                {
                    equipo = a["equipo"].ToString(),
                    nombre = a["nombre"].ToString(),
                    abreviatura = a["abreviatura"].ToString(),
                    empleado = a["empleado"].ToString(),
                    nombre_empleado = a["nombre_empleado"].ToString(),
                    status = a["status"].ToString(),
                    serie = a["serie"].ToString()
                }).ToList();
            }
            
            return equipos;
        }
        //traer tipos servicio
        public List<TipoServ> TraerTiposServ()
        {
            List<TipoServ>tipoServs = new List<TipoServ>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "TS");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                tipoServs = dt.AsEnumerable().Select(a =>
                new TipoServ
                {
                    Tipo_servicio = a["Tipo_servicio"].ToString(),
                    Nombre = a["Nombre"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return tipoServs;
        }
        //traer servicios dependientes
        public List<ServicioDep> TraerServiciosDep()
        {
            List<ServicioDep>dependientes = new List<ServicioDep>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "DS");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dependientes = dt.AsEnumerable().Select(a =>
                new ServicioDep
                {
                    servicio = a["servicio"].ToString(),
                    nom_servicio = a["nom_servicio"].ToString(),
                    servicio_dependiente = a["servicio_dependiente"].ToString(),
                    nom_dependiente = a["nom_dependiente"].ToString(),
                    notas = a["notas"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return dependientes;
        }
        //traer sistema equipos
        public List<SistemasEquipos> TraerSistemaEquipos()
        {
            List<SistemasEquipos> sistemas = new List<SistemasEquipos>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "SM");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sistemas = dt.AsEnumerable().Select(a =>
                new SistemasEquipos
                {
                    sistema_equipos = a["sistema_equipos"].ToString(),
                    nombre = a["nombre"].ToString(),
                    status = a["status"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return sistemas;
        }
        //traer conceptos servicios
        public List<ConceptosSServ> TraerConceptosS()
        {
            List<ConceptosSServ> conceptos = new List<ConceptosSServ>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "CS");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conceptos = dt.AsEnumerable().Select(a =>
                new ConceptosSServ
                {
                    concepto_servicio = a["concepto_servicio"].ToString(),
                    nombre = a["nombre"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return conceptos;
        }
        //traer conceptos gastos
        public List<ConceptosGServ> TraerConceptosG()
        {
            List<ConceptosGServ> conceptos = new List<ConceptosGServ>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "CG");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conceptos = dt.AsEnumerable().Select(a =>
                new ConceptosGServ
                {
                    concepto_gastos = a["concepto_gastos"].ToString(),
                    nombre = a["nombre"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return conceptos;
        }
        //traer servicio Editar
        public ServiciosModelView TraerServicio(string serv)
        {
            ServiciosModelView servicio = new ServiciosModelView();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Taller", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "R");
                sda.SelectCommand.Parameters.AddWithValue("@servicio", serv);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                servicio = dt.AsEnumerable().Select(a =>
                new ServiciosModelView
                {
                    servicio = a["servicio"].ToString(),
                    nombre = a["nombre"].ToString(),
                    status = a["status"].ToString(),
                    tipo_servicio=a["tipo_servicio"].ToString(),
                    concepto_gastos = a["concepto_gastos"].ToString(),
                    horas_mecanico = Convert.ToInt32(a["horas_mecanico"]),
                    minutos_mecanico = Convert.ToInt32(a["minutos_mecanico"]),
                    orden_mostrar = Convert.ToInt32(a["orden_mostrar"]),
                    concepto_servicio = a["concepto_servicio"].ToString(),
                    sistema_equipos = a["sistema_equipos"].ToString(),
                    dias = Convert.ToInt16(a["dias"]),
                    precio = Convert.ToDecimal(a["precio"])
                }).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return servicio;
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
        //traer proveedores
        public List<Proveedores> TraerProveedores()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                sda.SelectCommand.Parameters.AddWithValue("@oper", "P");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                proveedores = dt.AsEnumerable().Select(a =>
                new Proveedores
                {
                    razon_social=a["razon_social"].ToString(),
                    calle = a["calle"].ToString(),
                    cod_estab = a["cod_estab"].ToString(),
                    cod_prv = a["cod_prv"].ToString(),
                    status_proveedor = a["status_proveedor"].ToString()

                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return proveedores;
        }
        //traer equipo Editar
        public EquiposModelView TraerEquipo(string equipo)
        {
            EquiposModelView equipos = new EquiposModelView();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Equipos", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "R");
            sda.SelectCommand.Parameters.AddWithValue("@equipo",equipo);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            equipos = dt.AsEnumerable().Select(a =>
            new EquiposModelView
            {
                equipo = a["equipo"].ToString(),
                nombre = a["nombre"].ToString(),
                abreviatura = a["abreviatura"].ToString(),
                tipo_equipo = a["tipo_equipo"].ToString(),
                tipo_vehiculo = a["tipo_vehiculo"].ToString(),
                marca = a["marca"].ToString(),
                modelo = a["modelo"].ToString(),
                año = a["año"].ToString(),
                serie = a["serie"].ToString(),
                motor = a["motor"].ToString().Trim(),
                caracteristicas = a["caracteristicas"].ToString(),
                placas = a["placas"].ToString(),
                ultima_lectura = Convert.ToInt64(a["ultima_lectura"]),
                seguro = Convert.ToDecimal(a["seguro"]),
                tenencia = Convert.ToDecimal(a["tenencia"]),
                chofer = a["chofer"].ToString(),
                status = a["status"].ToString(),
                activo_fijo = a["activo_fijo"].ToString(),
                fecha_alta = Convert.ToDateTime(a["fecha_alta"]),
                cod_estab = a["cod_estab"].ToString(),
                uso_equipos = a["uso_equipos"].ToString(),
                codigo_economico = a["codigo_economico"].ToString(),
                //empleado = a["empleado"].ToString(),
                fecha_compra = Convert.ToDateTime(a["fecha_compra"]),
                costo = Convert.ToDecimal(a["costo"]),
                valor_comercial = Convert.ToDecimal(a["costo"]),
                abono_mensual = Convert.ToDecimal(a["abono_mensual"]),
                carga_estandar = a["carga_estandar"].ToString(),
                equipo_depende = a["equipo_depende"].ToString(),
                vida_util = Convert.ToInt32(a["vida_util"]),
                medida_vida_util = a["medida_vida_util"].ToString(),
                garantia = Convert.ToInt32(a["garantia"]),
                medida_garantia = a["medida_garantia"].ToString(),
                lote = a["lote"].ToString(),
                tanque1 = Convert.ToInt32(a["tanque1"]),
                tanque2 = Convert.ToInt32(a["tanque2"]),
                tanque3 = Convert.ToInt32(a["tanque3"]),
                combustible1 = a["combustible1"].ToString(),
                combustible2 = a["combustible2"].ToString(),
                combustible3 = a["combustible3"].ToString(),
                nivel_licencia = Convert.ToInt32(a["nivel_licencia"]),
                nivel_licencia_empresa = Convert.ToInt32(a["nivel_licencia_empresa"]),
                usa_lubricante = Convert.ToBoolean(a["usa_lubricante"]),
                vigencia_placas = Convert.ToDateTime(a["vigencia_placas"]),
                vigencia_circulacion = Convert.ToDateTime(a["vigencia_circulacion"]),
                vida_util2 = Convert.ToInt32(a["vida_util2"]),
                medida_vida_util2 = a["medida_vida_util2"].ToString(),
                garantia2 = Convert.ToInt32(a["garantia2"]),
                medida_garantia2 = a["medida_garantia2"].ToString(),
                area = a["area"].ToString(),
                departamento = a["departamento"].ToString(),
                tarjeta = a["tarjeta"].ToString(),
                ayudante = a["ayudante"].ToString(),
                RENDIMIENTO1 = Convert.ToDecimal(a["RENDIMIENTO1"]),
                RENDIMIENTO2 = Convert.ToDecimal(a["RENDIMIENTO2"]),
                RENDIMIENTO3 = Convert.ToDecimal(a["RENDIMIENTO3"]),
                recorrido_maximo = Convert.ToInt32(a["recorrido_maximo"]),
                version = a["version"].ToString(),
                odometro = a["odometro"].ToString(),
                llantas = Convert.ToInt32(a["llantas"]),
                llantas_extras = Convert.ToInt32(a["llantas_extras"]),
                llantas_eje1 = Convert.ToInt32(a["llantas_eje1"]),
                llantas_eje2 = Convert.ToInt32(a["llantas_eje2"]),
                llantas_eje3 = Convert.ToInt32(a["llantas_eje3"]),
                llantas_eje4 = Convert.ToInt32(a["llantas_eje4"]),
                llantas_eje5 = Convert.ToInt32(a["llantas_eje5"]),
                llantas_eje6 = Convert.ToInt32(a["llantas_eje6"]),
                color = a["color"].ToString(),
                ayudante2 = a["ayudante2"].ToString(),
                NombreAF = a["NombreAF"].ToString(),
                NombreAR = a["NombreAR"].ToString(),
                NombreDE = a["NombreDE"].ToString(),
                NombreDD = a["NombreDepende"].ToString(),
                sirve_odometro = Convert.ToBoolean(a["sirve_odometro"])
            }).SingleOrDefault();
            return equipos;
        }
        //guardar servicio dependiente
        public bool GuardarServicioDep(ServicioDep servicio, string operacion)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_DatosServicios", cnn);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Transaction = sqlTransaction;
                sda.SelectCommand.Parameters.AddWithValue("@oper", operacion);
                sda.SelectCommand.Parameters.AddWithValue("@servicio", servicio.servicio);
                sda.SelectCommand.Parameters.AddWithValue("@notas", servicio.notas);
                sda.SelectCommand.Parameters.AddWithValue("@notas_original", servicio.notas_original);
                sda.SelectCommand.Parameters.AddWithValue("@servicio_dependiente", servicio.servicio_dependiente);
                sda.SelectCommand.Parameters.AddWithValue("@servicio_dependiente_original", servicio.servicio_dependiente_original);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }

        }
        //guardar servicio
        public bool GuardarServicio(Servicios servicio, string operacion)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Taller", cnn);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Transaction = sqlTransaction;
                sda.SelectCommand.Parameters.AddWithValue("@oper", operacion);
                sda.SelectCommand.Parameters.AddWithValue("@servicio", servicio.servicio);
                sda.SelectCommand.Parameters.AddWithValue("@nombre", servicio.nombre);
                sda.SelectCommand.Parameters.AddWithValue("@tipo_servicio", servicio.tipo_servicio);
                sda.SelectCommand.Parameters.AddWithValue("@status", servicio.status);
                sda.SelectCommand.Parameters.AddWithValue("@concepto_gastos", servicio.concepto_gastos);
                sda.SelectCommand.Parameters.AddWithValue("@horas_mecanico", servicio.horas_mecanico);
                sda.SelectCommand.Parameters.AddWithValue("@minutos_mecanico", servicio.minutos_mecanico);
                sda.SelectCommand.Parameters.AddWithValue("@orden_mostrar", servicio.orden_mostrar);
                sda.SelectCommand.Parameters.AddWithValue("@concepto_servicio", servicio.concepto_servicio);
                sda.SelectCommand.Parameters.AddWithValue("@sistema_equipos", servicio.sistema_equipos);
                sda.SelectCommand.Parameters.AddWithValue("@dias", servicio.dias);
                sda.SelectCommand.Parameters.AddWithValue("@precio", servicio.precio);
                sda.SelectCommand.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ""));
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!string.IsNullOrEmpty(sda.SelectCommand.Parameters["@Msg"].Value.ToString()))
                {
                    throw new Exception(sda.SelectCommand.Parameters["@Msg"].Value.ToString());
                }
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                //return false;
                throw new Exception(ex.Message);
                
                
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
                
            }
            

        }
        //traer informacion de gasto de servicio
        public List<AlimentacionGastosServicios> TraerGS()
        {
            List<AlimentacionGastosServicios> GS = new List<AlimentacionGastosServicios>();
            try {
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", this.ConnectionString);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@oper", "C");
                sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GS = dt.AsEnumerable().Select(a =>
                new AlimentacionGastosServicios
                {
                    folio = a["folio"].ToString(),
                    transaccion = a["transaccion"].ToString(),
                    fecha_servicio = Convert.ToDateTime(a["fecha_servicio"]),
                    equipo = a["equipo"].ToString(),
                    cod_estab = a["cod_estab"].ToString(),
                    cod_prv = a["cod_prv"].ToString(),
                    notas = a["notas"].ToString(),
                    tNombre = a["tNombre"].ToString(),
                    eNombre = a["eNombre"].ToString(),
                    pNombre = a["pNombre"].ToString(),
                    eqNombre = a["eqNombre"].ToString(),
                    servicio = a["Servicios"].ToString()
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return GS;
        }
        //guardar servicio
        public bool GuardarGastosServicios(AlimentacionGastosServicios GS)
        {
            DateTime fecha1 = Convert.ToDateTime("01/01/1773");
            DateTime fecha2 = Convert.ToDateTime("31/12/9999");
            string fecha = DateTime.Today.ToString("dd-MM-yyyy");
            if(GS.fecha_cancelacion <= fecha1 || GS.fecha_cancelacion >= fecha2)
            {
                //GS.fecha_cancelacion =
            }
            if (GS.fecha_elaboracion <= fecha1 || GS.fecha_elaboracion >= fecha2)
            {
                GS.fecha_elaboracion = Convert.ToDateTime(fecha);
            }
            if (GS.fecha_entrega <= fecha1 || GS.fecha_entrega >= fecha2)
            {
                GS.fecha_entrega = Convert.ToDateTime(fecha);
            }
            if (GS.fecha_servicio <= fecha1 || GS.fecha_servicio >= fecha2)
            {
                GS.fecha_servicio = Convert.ToDateTime(fecha);
            }
            if (GS.fecha_recepcion <= fecha1 || GS.fecha_recepcion>= fecha2)
            {
                GS.fecha_recepcion = Convert.ToDateTime(fecha);
            }
            if (GS.usuario == null)
            {
                GS.usuario = "1";
            }
            if(GS.factura_proveedor == null)
            {
                GS.factura_proveedor = "";
            }
            if(GS.cod_cte == null)
            {
                GS.cod_cte = "";
            }
            if(GS.cod_prv == null)
            {
                GS.cod_prv = "";
            }
            if(GS.notas == null)
            {
                GS.notas = "";
            }
            if(GS.notas2 == null)
            {
                GS.notas2 = "";
            }
            if (GS.mecanico == null)
            {
                GS.mecanico = "";
            }
            if (GS.operador == null)
            {
                GS.operador = "";
            }
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            
            try
            {
                if(GS.factura_proveedor != null && GS.folio_propio != null)
                {
                        try
                        {
                            cnn.Open();
                            sqlTransaction = cnn.BeginTransaction();
                            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", cnn);
                            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            sda.SelectCommand.Transaction = sqlTransaction;
                            sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                            sda.SelectCommand.Parameters.AddWithValue("@factura_proveedor", GS.factura_proveedor);
                            sda.SelectCommand.Parameters.AddWithValue("@oper", "G");
                            sda.SelectCommand.Parameters.AddWithValue("@suboper", "FA");
                            sda.SelectCommand.Parameters.AddWithValue("@cod_prv", GS.cod_prv);
                            sda.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                            sda.SelectCommand.Parameters.AddWithValue("@importe", GS.Neto);
                            sda.SelectCommand.Parameters.AddWithValue("@iva", GS.IVA);
                            sda.SelectCommand.Parameters.AddWithValue("@iva_ret", GS.IVARet);
                            sda.SelectCommand.Parameters.AddWithValue("@isr_ret", GS.ISRRet);
                            sda.SelectCommand.Parameters.AddWithValue("@neto", GS.total);
                            sda.SelectCommand.Parameters.AddWithValue("@cod_usr", GS.usuario);
                            sda.SelectCommand.Parameters.AddWithValue("@cod_estab", GS.cod_estab);
                            sda.SelectCommand.Parameters.AddWithValue("@folio_propio", GS.folio_propio);
                            sda.SelectCommand.Parameters.AddWithValue("@folio_fiscal", "");
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            sqlTransaction.Commit();
                            cnn.Close();
                        }
                        catch(Exception e)
                        {
                            sqlTransaction.Rollback();
                            throw new Exception(e.Message);
                        }
                    try
                    {
                        foreach(var i in GS.servicioGS)
                        {
                            cnn.Open();
                            sqlTransaction = cnn.BeginTransaction();
                            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", cnn);
                            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            sda.SelectCommand.Transaction = sqlTransaction;
                            sda.SelectCommand.Parameters.AddWithValue("@folio", "");
                            sda.SelectCommand.Parameters.AddWithValue("@oper", "G");
                            sda.SelectCommand.Parameters.AddWithValue("@suboper", "MF");
                            sda.SelectCommand.Parameters.AddWithValue("@folio_propio", GS.folio_propio);
                            sda.SelectCommand.Parameters.AddWithValue("@cod_prv", GS.cod_prv);
                            sda.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                            sda.SelectCommand.Parameters.AddWithValue("@concepto", i.concepto);
                            sda.SelectCommand.Parameters.AddWithValue("@importe", i.importe);
                            sda.SelectCommand.Parameters.AddWithValue("@iva", i.iva);
                            sda.SelectCommand.Parameters.AddWithValue("@iva_ret", i.iva_ret);
                            sda.SelectCommand.Parameters.AddWithValue("@isr_ret", i.isr_ret);
                            sda.SelectCommand.Parameters.AddWithValue("@cod_estab", GS.cod_estab);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            sqlTransaction.Commit();
                            cnn.Close();
                        }
                        
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        throw new Exception(e.Message);
                    }
                }

                try
                {
                    cnn.Open();
                    sqlTransaction = cnn.BeginTransaction();
                    SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", cnn);
                    sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sda.SelectCommand.Transaction = sqlTransaction;
                    sda.SelectCommand.Parameters.AddWithValue("@folio", GS.folio.Trim());
                    sda.SelectCommand.Parameters.AddWithValue("@oper", "G");
                    sda.SelectCommand.Parameters.AddWithValue("@suboper", "OR");
                    sda.SelectCommand.Parameters.AddWithValue("@transaccion", "273");

                    sda.SelectCommand.Parameters.AddWithValue("@fecha_servicio", GS.fecha_servicio);
                    sda.SelectCommand.Parameters.AddWithValue("@equipo", GS.equipo);
                    sda.SelectCommand.Parameters.AddWithValue("@status", "V");
                    sda.SelectCommand.Parameters.AddWithValue("@usuario", GS.usuario);
                    sda.SelectCommand.Parameters.AddWithValue("@usuario_cancelacion", "");

                    sda.SelectCommand.Parameters.AddWithValue("@cod_estab", GS.cod_estab);
                    sda.SelectCommand.Parameters.AddWithValue("@notas", GS.notas);

                    sda.SelectCommand.Parameters.AddWithValue("@cod_prv", GS.cod_prv);
                    if (GS.fecha_cancelacion <= fecha1 || GS.fecha_cancelacion >= fecha2)
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@fecha_cancelacion", null);
                    }
                    else
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@fecha_cancelacion", GS.fecha_cancelacion);
                    }
                    sda.SelectCommand.Parameters.AddWithValue("@fecha_elaboracion", GS.fecha_elaboracion);
                    sda.SelectCommand.Parameters.AddWithValue("@cod_cte", GS.cod_cte);
                    sda.SelectCommand.Parameters.AddWithValue("@recepcionista", "");
                    sda.SelectCommand.Parameters.AddWithValue("@fecha_recepcion", GS.fecha_recepcion);
                    sda.SelectCommand.Parameters.AddWithValue("@torreta", "");
                    sda.SelectCommand.Parameters.AddWithValue("@fecha_entrega", GS.fecha_entrega);
                    sda.SelectCommand.Parameters.AddWithValue("@factura_proveedor", GS.factura_proveedor.Trim());

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    sqlTransaction.Commit();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    //return false;
                    throw new Exception(ex.Message);
                }
                try
                {
                    foreach(var i in GS.servicioGS)
                    {
                        cnn.Open();
                        sqlTransaction = cnn.BeginTransaction();
                        SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_alimentacionGS_equipos", cnn);
                        sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sda.SelectCommand.Transaction = sqlTransaction;
                        sda.SelectCommand.Parameters.AddWithValue("@folio", GS.folio.Trim());
                        sda.SelectCommand.Parameters.AddWithValue("@oper", "G"); 
                        sda.SelectCommand.Parameters.AddWithValue("@suboper", "MO");
                        sda.SelectCommand.Parameters.AddWithValue("@transaccion", "273");
                        sda.SelectCommand.Parameters.AddWithValue("@fecha_servicio", GS.fecha_servicio);
                        sda.SelectCommand.Parameters.AddWithValue("@equipo", GS.equipo);
                        sda.SelectCommand.Parameters.AddWithValue("@servicio", i.servicio);
                        sda.SelectCommand.Parameters.AddWithValue("@status", "V");
                        sda.SelectCommand.Parameters.AddWithValue("@cod_estab", GS.cod_estab);
                        sda.SelectCommand.Parameters.AddWithValue("@cod_prv", GS.cod_prv);
                        sda.SelectCommand.Parameters.AddWithValue("@mecanico", GS.mecanico);
                        sda.SelectCommand.Parameters.AddWithValue("@refacciones", GS.refacciones);
                        sda.SelectCommand.Parameters.AddWithValue("@mano_obra_mecanico", GS.mano_obra_mecanico);
                        sda.SelectCommand.Parameters.AddWithValue("@mano_obra_total", GS.mano_obra_total);
                        sda.SelectCommand.Parameters.AddWithValue("@trabajos_otros_talleres", i.importe);
                        sda.SelectCommand.Parameters.AddWithValue("@otros_gastos", GS.otros_gastos);
                        sda.SelectCommand.Parameters.AddWithValue("@lectura", i.lectura);
                        sda.SelectCommand.Parameters.AddWithValue("@cantidad", i.cantidad);
                        sda.SelectCommand.Parameters.AddWithValue("@total", i.NetoServ);
                        sda.SelectCommand.Parameters.AddWithValue("@operador", GS.operador);
                        sda.SelectCommand.Parameters.AddWithValue("@notas2", i.notasserv);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        

                        sqlTransaction.Commit();
                        cnn.Close();
                    }
                }
                catch(Exception ex)
                {
                    sqlTransaction.Rollback();
                    //return false;
                    throw new Exception(ex.Message);
                }
                    
                    return true;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                //return false;
                throw new Exception(ex.Message);


            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }

            }


        }

        //guardar equipo
        public bool GuardarEquipo(Equipos equipo, string operacion)
        {
            DateTime fecha1 = Convert.ToDateTime("01/01/1773");
            DateTime fecha2 = Convert.ToDateTime("31/12/9999");
            string fecha = DateTime.Today.ToString("dd-MM-yyyy");
            if (equipo.es_activo_fijo != false)
            {
                operacion = "A";
            }
            if(equipo.fecha_alta <= fecha1 || equipo.fecha_alta >= fecha2){
                equipo.fecha_alta = DateTime.Today;
            }
            if (equipo.fecha_compra <= fecha1 || equipo.fecha_compra >= fecha2)
            {
                equipo.fecha_compra = DateTime.Today;
            }
            if (equipo.vigencia_circulacion <= fecha1 || equipo.vigencia_circulacion >= fecha2)
            {
                equipo.vigencia_circulacion = DateTime.Today;
            }
            if (equipo.vigencia_placas <= fecha1 || equipo.vigencia_placas >= fecha2)
            {
                equipo.vigencia_placas = DateTime.Today;
            }
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Equipos", cnn);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Transaction = sqlTransaction;
                sda.SelectCommand.Parameters.AddWithValue("@oper", operacion);
                sda.SelectCommand.Parameters.AddWithValue("@equipo", equipo.equipo);
                sda.SelectCommand.Parameters.AddWithValue("@nombre", equipo.nombre);
                sda.SelectCommand.Parameters.AddWithValue("@abreviatura", equipo.abreviatura);
                sda.SelectCommand.Parameters.AddWithValue("@tipo_equipo", equipo.tipo_equipo);
                sda.SelectCommand.Parameters.AddWithValue("@tipo_vehiculo", equipo.tipo_vehiculo);
                sda.SelectCommand.Parameters.AddWithValue("@marca", equipo.marca);
                sda.SelectCommand.Parameters.AddWithValue("@modelo", equipo.modelo);
                sda.SelectCommand.Parameters.AddWithValue("@año", equipo.año);
                sda.SelectCommand.Parameters.AddWithValue("@serie", equipo.serie);
                sda.SelectCommand.Parameters.AddWithValue("@motor", equipo.motor);
                sda.SelectCommand.Parameters.AddWithValue("@caracteristicas", equipo.caracteristicas);
                sda.SelectCommand.Parameters.AddWithValue("@placas", equipo.placas);
                sda.SelectCommand.Parameters.AddWithValue("@ultima_lectura", equipo.ultima_lectura);
                sda.SelectCommand.Parameters.AddWithValue("@seguro", equipo.seguro);
                sda.SelectCommand.Parameters.AddWithValue("@tenencia", equipo.tenencia);
                sda.SelectCommand.Parameters.AddWithValue("@chofer", equipo.chofer);
                sda.SelectCommand.Parameters.AddWithValue("@status", equipo.status);
                sda.SelectCommand.Parameters.AddWithValue("@activo_fijo", equipo.activo_fijo);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_alta",equipo.fecha_alta);
                sda.SelectCommand.Parameters.AddWithValue("@cod_estab", equipo.cod_estab);
                sda.SelectCommand.Parameters.AddWithValue("@uso_equipos", equipo.uso_equipos);
                sda.SelectCommand.Parameters.AddWithValue("@codigo_economico", equipo.codigo_economico);
                //sda.SelectCommand.Parameters.AddWithValue("@empleado", 1); //este no
                sda.SelectCommand.Parameters.AddWithValue("@fecha_compra", equipo.fecha_compra);
                sda.SelectCommand.Parameters.AddWithValue("@costo", equipo.costo);
                sda.SelectCommand.Parameters.AddWithValue("@valor_comercial", equipo.valor_comercial);
                sda.SelectCommand.Parameters.AddWithValue("@abono_mensual", equipo.abono_mensual);
                sda.SelectCommand.Parameters.AddWithValue("@carga_estandar", equipo.carga_estandar);
                sda.SelectCommand.Parameters.AddWithValue("@equipo_depende", equipo.equipo_depende);
                sda.SelectCommand.Parameters.AddWithValue("@vida_util", equipo.vida_util);
                sda.SelectCommand.Parameters.AddWithValue("@medida_vida_util", equipo.medida_vida_util);
                sda.SelectCommand.Parameters.AddWithValue("@garantia", equipo.garantia);
                sda.SelectCommand.Parameters.AddWithValue("@medida_garantia", equipo.medida_garantia);
                sda.SelectCommand.Parameters.AddWithValue("@lote", equipo.lote);
                sda.SelectCommand.Parameters.AddWithValue("@tanque1", equipo.tanque1);
                sda.SelectCommand.Parameters.AddWithValue("@tanque2", equipo.tanque2);
                sda.SelectCommand.Parameters.AddWithValue("@tanque3", equipo.tanque3);
                sda.SelectCommand.Parameters.AddWithValue("@combustible1", equipo.combustible1);
                sda.SelectCommand.Parameters.AddWithValue("@combustible2", equipo.combustible2);
                sda.SelectCommand.Parameters.AddWithValue("@combustible3", equipo.combustible3);
                sda.SelectCommand.Parameters.AddWithValue("@nivel_licencia", equipo.nivel_licencia);
                sda.SelectCommand.Parameters.AddWithValue("@nivel_licencia_empresa", equipo.nivel_licencia_empresa);
                sda.SelectCommand.Parameters.AddWithValue("@usa_lubricante", equipo.usa_lubricante);
                sda.SelectCommand.Parameters.AddWithValue("@vigencia_placas", equipo.vigencia_placas);
                sda.SelectCommand.Parameters.AddWithValue("@vigencia_circulacion", equipo.vigencia_circulacion);
                sda.SelectCommand.Parameters.AddWithValue("@vida_util2", equipo.vida_util2);
                sda.SelectCommand.Parameters.AddWithValue("@medida_vida_util2", equipo.medida_vida_util2);
                sda.SelectCommand.Parameters.AddWithValue("@garantia2", equipo.garantia2);
                sda.SelectCommand.Parameters.AddWithValue("@medida_garantia2", equipo.medida_garantia2);
                sda.SelectCommand.Parameters.AddWithValue("@area", equipo.area);
                sda.SelectCommand.Parameters.AddWithValue("@departamento", equipo.departamento);
                //sda.SelectCommand.Parameters.AddWithValue("@tarjeta", 1);//este no
                sda.SelectCommand.Parameters.AddWithValue("@ayudante", equipo.ayudante);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO1", equipo.RENDIMIENTO1);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO2", equipo.RENDIMIENTO2);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO3", equipo.RENDIMIENTO3);
                sda.SelectCommand.Parameters.AddWithValue("@recorrido_maximo", equipo.recorrido_maximo);
                sda.SelectCommand.Parameters.AddWithValue("@version", equipo.version);
                sda.SelectCommand.Parameters.AddWithValue("@odometro", equipo.odometro);
                sda.SelectCommand.Parameters.AddWithValue("@llantas", equipo.llantas);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_extras", equipo.llantas_extras);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje1", equipo.llantas_eje1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje2", equipo.llantas_eje2);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje3", equipo.llantas_eje3);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje4", equipo.llantas_eje4);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje5", equipo.llantas_eje5);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje6", equipo.llantas_eje6);
                sda.SelectCommand.Parameters.AddWithValue("@color", equipo.color);
                sda.SelectCommand.Parameters.AddWithValue("@ayudante2", equipo.ayudante2);
                sda.SelectCommand.Parameters.AddWithValue("@sirve_odometro", equipo.sirve_odometro);
                //activo fijo
                sda.SelectCommand.Parameters.AddWithValue("@descripcion", equipo.nombre);
                sda.SelectCommand.Parameters.AddWithValue("@fecha",Convert.ToDateTime(fecha));
                sda.SelectCommand.Parameters.AddWithValue("@fecha_adquisicion", Convert.ToDateTime(fecha));
                sda.SelectCommand.Parameters.AddWithValue("@monto_original_inversion", 0);
                sda.SelectCommand.Parameters.AddWithValue("@usuario", 1);//MG usuario
                //sda.SelectCommand.Parameters.AddWithValue("@usuario_baja", );
                sda.SelectCommand.Parameters.AddWithValue("@fecha_modificacion", Convert.ToDateTime(fecha));
                sda.SelectCommand.Parameters.AddWithValue("@talla", "");
                sda.SelectCommand.Parameters.AddWithValue("@tipo_activo_fijo", "");
                sda.SelectCommand.Parameters.AddWithValue("@transaccion", "57");
                sda.SelectCommand.Parameters.AddWithValue("@ubicacion", "");
                sda.SelectCommand.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ""));
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!string.IsNullOrEmpty(sda.SelectCommand.Parameters["@Msg"].Value.ToString()))
                {
                    throw new Exception(sda.SelectCommand.Parameters["@Msg"].Value.ToString());
                }
                else
                {

                }
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                return false;//probando
                throw new Exception(ex.Message);
                
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }

        }
        //Traer sabores
        public List<Sabores> TraerSabores()
        {
            List<Sabores> sabores = new List<Sabores>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Sabores", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Operacion", "R");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sabores = dt.AsEnumerable().Select(a =>
            new Sabores
            {
                sabor = a["sabor"].ToString(),
                nombre = a["nombre"].ToString(),
                abreviatura = a["abreviatura"].ToString(),
                status = a["status"].ToString()
            }).ToList();

            return sabores;
        }

        //lista de status
        public List<Status> TraerStatus()
        {
            List<Status> sts = new List<Status>();
            sts.Add(new Status { status = "C", nombre = "Cancelado" });
            sts.Add(new Status { status = "V", nombre = "Vigente" });
            return sts;
        }

        

        public Aromas TraerAroma(string codigo)
        {
            Aromas aromas = new Aromas();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Aromas", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Operacion", "R");
            sda.SelectCommand.Parameters.AddWithValue("@CodigoAroma", codigo);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            aromas = dt.AsEnumerable().Select(a =>
            new Aromas
            {
                aroma = a["aroma"].ToString(),
                nombre = a["nombre"].ToString(),
                abreviatura = a["abreviatura"].ToString(),
                status = a["status"].ToString()
            }).SingleOrDefault();

            return aromas;
        }
        public Sabores TraerSabor(string codigo)
        {
           
            Sabores sabores = new Sabores();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Sabores", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Operacion", "R");
            sda.SelectCommand.Parameters.AddWithValue("@CodigoSabor", codigo);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sabores = dt.AsEnumerable().Select(a =>
            new Sabores
            {
                sabor = a["sabor"].ToString(),
                nombre = a["nombre"].ToString(),
                abreviatura = a["abreviatura"].ToString(),
                status = a["status"].ToString()
            }).SingleOrDefault();

            return sabores;
        }

        public  bool  GuardarAroma(Aromas aroma, string operacion)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Aromas", cnn);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Transaction = sqlTransaction;
                sda.SelectCommand.Parameters.AddWithValue("@Operacion", operacion);
                sda.SelectCommand.Parameters.AddWithValue("@CodigoAroma", aroma.aroma);
                sda.SelectCommand.Parameters.AddWithValue("@Nombre", aroma.nombre);
                sda.SelectCommand.Parameters.AddWithValue("@Abrev", aroma.abreviatura);
                sda.SelectCommand.Parameters.AddWithValue("@Status", aroma.status);
                sda.SelectCommand.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, false, 0, 0,"", DataRowVersion.Current, ""));
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!string.IsNullOrEmpty(sda.SelectCommand.Parameters["@Msg"].Value.ToString()))
                {
                    throw new Exception(sda.SelectCommand.Parameters["@Msg"].Value.ToString());
                }
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }
            
        }
        public bool GuardarSabor(Sabores sabor, string operacion)
        {
            SqlTransaction sqlTransaction = null;
            SqlConnection cnn = new SqlConnection(this.ConnectionString);
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Demo_Sabores", cnn);
                sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sda.SelectCommand.Transaction = sqlTransaction;
                sda.SelectCommand.Parameters.AddWithValue("@Operacion", operacion);
                sda.SelectCommand.Parameters.AddWithValue("@CodigoSabor", sabor.sabor);
                sda.SelectCommand.Parameters.AddWithValue("@Nombre", sabor.nombre);
                sda.SelectCommand.Parameters.AddWithValue("@Abrev", sabor.abreviatura);
                sda.SelectCommand.Parameters.AddWithValue("@Status", sabor.status);
                sda.SelectCommand.Parameters.Add(new SqlParameter("@Msg", SqlDbType.VarChar, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Current, ""));
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (!string.IsNullOrEmpty(sda.SelectCommand.Parameters["@Msg"].Value.ToString()))
                {
                    throw new Exception(sda.SelectCommand.Parameters["@Msg"].Value.ToString());
                }
                sqlTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnn.State != ConnectionState.Closed)
                {
                    cnn.Close();
                }
            }

        }
    }
}
