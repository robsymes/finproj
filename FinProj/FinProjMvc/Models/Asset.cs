using System;
using System.Collections.Generic;
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

        public DateTime? BuyDate { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime? SellDate { get; set; }  // Can perhaps have validation to ensure this is after the buy date
        public decimal? SellPrice { get; set; }

        // public AssetIncome GetIncome(DateTime date)
    }
}
