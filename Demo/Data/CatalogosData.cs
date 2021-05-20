using Demo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
