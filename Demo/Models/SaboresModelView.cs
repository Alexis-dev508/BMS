using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class SaboresModelView: Sabores
    {
        public SaboresModelView()
        {
            this.StatusList = new List<SelectListItem>();
        }
        public IList<SelectListItem> StatusList { get; set; }
    }
}
