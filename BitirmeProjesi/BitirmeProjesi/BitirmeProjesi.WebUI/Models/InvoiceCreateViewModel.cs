using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Models
{
    public class InvoiceCreateViewModel
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        public double Dues { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public double ElectricityBill { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public double WaterBill { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public double GasBill { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Month { get; set; }
    }
}
