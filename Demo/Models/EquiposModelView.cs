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


    }
}
