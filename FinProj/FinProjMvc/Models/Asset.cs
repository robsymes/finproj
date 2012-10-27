using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinProjMvc.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        
        public bool Enabled { get; set; }  // or this flag could be called "Active"?

        [Required(ErrorMessage = "A Name is required")]
        public string Name { get; set; }

        public virtual List<Payment> Payments { get; set; }

    }
}
