using FinProjMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinProjMvc.ViewModels
{
    public class RowViewModel
    {
        public string Name { get; set; }
        public string LinkUrl { get; set; }  // Optional
        public List<decimal> Values { get; set; }
    }

    public class ProjectionViewModel
    {
        public List<RowViewModel> AssetRows { get; set; }
        public RowViewModel CashflowRow { get; set; }
        public RowViewModel CashRow { get; set; }
    }
}
