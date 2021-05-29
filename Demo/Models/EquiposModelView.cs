using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class EquiposModelView:Equipos
    {
        public EquiposModelView()
        {
            this.MarcasList = new List<SelectListItem>();
            this.StatusList = new List<SelectListItem>();
            this.ModelosList = new List<SelectListItem>();
            this.VersionList = new List<SelectListItem>();
            this.AnniosList = new List<SelectListItem>();
            this.TipoEquipoList = new List<SelectListItem>();
            this.UsosList = new List<SelectListItem>();
            this.EstabList = new List<SelectListItem>();
            this.OdometroList = new List<SelectListItem>();
            this.ColorList = new List<SelectListItem>();
            this.FrecuenciaList = new List<SelectListItem>();

            this.MedidaGarantiaList = new List<SelectListItem>();
            this.MedidaGarantia2List = new List<SelectListItem>();
            this.MedidaVidaUtilList = new List<SelectListItem>();
            this.MedidaVidaUtil2List = new List<SelectListItem>();

            this.TipoVehicList = new List<SelectListItem>();
            this.ChoferList = new List<SelectListItem>();
            this.CargaEstList = new List<SelectListItem>();
            this.AyudanteList = new List<SelectListItem>();
            this.Tanque1List = new List<SelectListItem>();
            this.Tanque2List = new List<SelectListItem>();
            this.Tanque3List = new List<SelectListItem>();
        }

        public IList<SelectListItem> MarcasList { get; set; }
        public IList<SelectListItem> StatusList { get; set; }
        public IList<SelectListItem> ModelosList { get; set; }
        public IList<SelectListItem> VersionList { get; set; }
        public IList<SelectListItem> AnniosList { get; set; }
        public IList<SelectListItem> TipoEquipoList { get; set; }
        public IList<SelectListItem> UsosList { get; set; }
        public IList<SelectListItem> EstabList { get; set; }
        public IList<SelectListItem> OdometroList { get; set; }
        public IList<SelectListItem> ColorList { get; set; }
        public IList<SelectListItem> FrecuenciaList { get; set; }

        public IList<SelectListItem> MedidaGarantiaList { get; set; }
        public IList<SelectListItem> MedidaGarantia2List { get; set; }
        public IList<SelectListItem> MedidaVidaUtilList { get; set; }
        public IList<SelectListItem> MedidaVidaUtil2List { get; set; }

        public IList<SelectListItem> TipoVehicList { get; set; }
        public IList<SelectListItem> ChoferList { get; set; }
        public IList<SelectListItem> CargaEstList { get; set; }
        public IList<SelectListItem> AyudanteList { get; set; }
        public IList<SelectListItem> Tanque1List { get; set; }
        public IList<SelectListItem> Tanque2List { get; set; }
        public IList<SelectListItem> Tanque3List { get; set; }

    }
}
