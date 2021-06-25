using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class AlimentacionGSModelView:AlimentacionGastosServicios
    {
        public AlimentacionGSModelView()
        {
            this.EstabList = new List<SelectListItem>();
        }
        public IList<SelectListItem> EstabList { get; set; }

    }
    
}
