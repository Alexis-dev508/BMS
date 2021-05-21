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
           
        }

        public IList<SelectListItem> MarcasList { get; set; }
        public IList<SelectListItem> StatusList { get; set; }

      

    }
}
