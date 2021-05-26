using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //tarer modelos
        public List<ModelosEquipos> TraerModelos()
        {
            List<ModelosEquipos> modelos = new List<ModelosEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "MO");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            modelos = dt.AsEnumerable().Select(a =>
            new ModelosEquipos
            {
                marca_equipos = a["marca_equipos"].ToString(),
                modelo_equipos = a["modelo_equipos"].ToString(),
                nombre = a["nombre"].ToString()
            }).ToList();
            return modelos;
        }
        //traer versiones
        public List<VersionesEquipos> TraerVersiones()
        {
            List<VersionesEquipos> versiones = new List<VersionesEquipos>();

            SqlDataAdapter sda = new SqlDataAdapter("dbo.DEMO_DATOSEQUIPOS", this.ConnectionString);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@oper", "VE");
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
        //traer activos fijos
        public List<ActivosFiEquipos> TraerActivosFi()
        {
            List<ActivosFiEquipos> activosFi = new List<ActivosFiEquipos>();

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
            return activosFi;
        }
        //traer tipo vehiculo
        public List<TiposVeEquipos> TraerTiposVehiculos()
        {
            List<TiposVeEquipos> tiposVe = new List<TiposVeEquipos>();

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
        //traer accesorios
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
        //traer informacion de equipos
        public List<Equipos> TraerEquipos()
        {
            List<Equipos> equipos = new List<Equipos>();

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
                status = a["status"].ToString(),
                serie = a["serie"].ToString()
            }).ToList();
            return equipos;
        }

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
                motor = a["motor"].ToString(),
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
                empleado = a["empleado"].ToString(),
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
                sirve_odometro = Convert.ToBoolean(a["sirve_odometro"])
            }).SingleOrDefault();

            return equipos;
        }

        //guardar equipo
        public bool GuardarEquipo(Equipos equipo, string operacion)
        {
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
                sda.SelectCommand.Parameters.AddWithValue("@tipo_vehiculo", 1);
                sda.SelectCommand.Parameters.AddWithValue("@marca", equipo.marca);
                sda.SelectCommand.Parameters.AddWithValue("@modelo", equipo.modelo);
                sda.SelectCommand.Parameters.AddWithValue("@año", equipo.año);
                sda.SelectCommand.Parameters.AddWithValue("@serie", equipo.serie);
                sda.SelectCommand.Parameters.AddWithValue("@motor", 1);
                sda.SelectCommand.Parameters.AddWithValue("@caracteristicas", equipo.caracteristicas);
                sda.SelectCommand.Parameters.AddWithValue("@placas", 1);
                sda.SelectCommand.Parameters.AddWithValue("@ultima_lectura", 1);
                sda.SelectCommand.Parameters.AddWithValue("@seguro", 1);
                sda.SelectCommand.Parameters.AddWithValue("@tenencia", 1);
                sda.SelectCommand.Parameters.AddWithValue("@chofer", 1);
                sda.SelectCommand.Parameters.AddWithValue("@status", equipo.status);
                sda.SelectCommand.Parameters.AddWithValue("@activo_fijo", equipo.activo_fijo);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_alta", "01/01/2000");
                sda.SelectCommand.Parameters.AddWithValue("@cod_estab", equipo.cod_estab);
                sda.SelectCommand.Parameters.AddWithValue("@uso_equipos", equipo.uso_equipos);
                sda.SelectCommand.Parameters.AddWithValue("@codigo_economico", equipo.codigo_economico);
                sda.SelectCommand.Parameters.AddWithValue("@empleado", 1);
                sda.SelectCommand.Parameters.AddWithValue("@fecha_compra", "01/01/2000");
                sda.SelectCommand.Parameters.AddWithValue("@costo", "1");
                sda.SelectCommand.Parameters.AddWithValue("@valor_comercial", 1);
                sda.SelectCommand.Parameters.AddWithValue("@abono_mensual", 1);
                sda.SelectCommand.Parameters.AddWithValue("@carga_estandar", 1);
                sda.SelectCommand.Parameters.AddWithValue("@equipo_depende", equipo.equipo_depende);
                sda.SelectCommand.Parameters.AddWithValue("@vida_util", equipo.vida_util);
                sda.SelectCommand.Parameters.AddWithValue("@medida_vida_util", equipo.medida_vida_util);
                sda.SelectCommand.Parameters.AddWithValue("@garantia", equipo.garantia);
                sda.SelectCommand.Parameters.AddWithValue("@medida_garantia", equipo.medida_garantia);
                sda.SelectCommand.Parameters.AddWithValue("@lote", equipo.lote);
                sda.SelectCommand.Parameters.AddWithValue("@tanque1", 1);
                sda.SelectCommand.Parameters.AddWithValue("@tanque2", 1);
                sda.SelectCommand.Parameters.AddWithValue("@tanque3", 1);
                sda.SelectCommand.Parameters.AddWithValue("@combustible1", 1);
                sda.SelectCommand.Parameters.AddWithValue("@combustible2", 1);
                sda.SelectCommand.Parameters.AddWithValue("@combustible3", 1);
                sda.SelectCommand.Parameters.AddWithValue("@nivel_licencia", 1);
                sda.SelectCommand.Parameters.AddWithValue("@nivel_licencia_empresa", 1);
                sda.SelectCommand.Parameters.AddWithValue("@usa_lubricante", 1);
                sda.SelectCommand.Parameters.AddWithValue("@vigencia_placas", 1);
                sda.SelectCommand.Parameters.AddWithValue("@vigencia_circulacion", 1);
                sda.SelectCommand.Parameters.AddWithValue("@vida_util2", equipo.vida_util2);
                sda.SelectCommand.Parameters.AddWithValue("@medida_vida_util2", equipo.medida_vida_util2);
                sda.SelectCommand.Parameters.AddWithValue("@garantia2", equipo.garantia2);
                sda.SelectCommand.Parameters.AddWithValue("@medida_garantia2", equipo.medida_garantia2);
                sda.SelectCommand.Parameters.AddWithValue("@area", equipo.area);
                sda.SelectCommand.Parameters.AddWithValue("@departamento", equipo.departamento);
                sda.SelectCommand.Parameters.AddWithValue("@tarjeta", 1);
                sda.SelectCommand.Parameters.AddWithValue("@ayudante", 1);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO1", 1);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO2", 1);
                sda.SelectCommand.Parameters.AddWithValue("@RENDIMIENTO3", 1);
                sda.SelectCommand.Parameters.AddWithValue("@recorrido_maximo", equipo.recorrido_maximo);
                sda.SelectCommand.Parameters.AddWithValue("@version", equipo.version);
                sda.SelectCommand.Parameters.AddWithValue("@odometro", equipo.odometro);
                sda.SelectCommand.Parameters.AddWithValue("@llantas", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_extras", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje1", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje2", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje3", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje4", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje5", 1);
                sda.SelectCommand.Parameters.AddWithValue("@llantas_eje6", 1);
                sda.SelectCommand.Parameters.AddWithValue("@color", equipo.color);
                sda.SelectCommand.Parameters.AddWithValue("@ayudante2", 1);
                sda.SelectCommand.Parameters.AddWithValue("@sirve_odometro", equipo.sirve_odometro);
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

        //NUEVO!!!!!!
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
