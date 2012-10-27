using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinProjMvc.Models
{
    public class Credit
    {
        public int CreditId { get; set; }

        [Required(ErrorMessage = "A Date is required")]
        [DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "An amount is required")]
        public decimal Amount { get; set; }

    }
}
