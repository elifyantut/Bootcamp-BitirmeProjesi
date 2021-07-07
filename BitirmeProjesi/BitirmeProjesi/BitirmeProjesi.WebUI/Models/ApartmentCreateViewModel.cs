using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Models
{
    public class ApartmentCreateViewModel
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string Block { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserType { get; set; }

    }
}
