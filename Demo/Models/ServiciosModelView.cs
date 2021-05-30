using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ServiciosModelView:Servicios
    {
        public ServiciosModelView()
        {
            this.TipoServList = new List<SelectListItem>();
            this.ConceptoServList = new List<SelectListItem>();
            this.ConceptoGList = new List<SelectListItem>();
            this.SistemasList = new List<SelectListItem>();
            this.StatusList = new List<SelectListItem>();

        }
        public IList<SelectListItem> TipoServList { get; set; }
        public IList<SelectListItem> ConceptoServList { get; set; }
        public IList<SelectListItem> ConceptoGList { get; set; }
        public IList<SelectListItem> SistemasList { get; set; }
        public IList<SelectListItem> StatusList { get; set; }
    }
}
