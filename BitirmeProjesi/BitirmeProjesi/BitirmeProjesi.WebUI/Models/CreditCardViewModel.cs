using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Models
{
    public class CreditCardViewModel
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string Owner { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ValidMonth { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ValidYear { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Cvv { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Money { get; set; }
    }
}
