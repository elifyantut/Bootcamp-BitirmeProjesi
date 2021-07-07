using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI.Models
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [StringLength(maximumLength:11,ErrorMessage ="TC No 11 Haneli olmalı",MinimumLength =11)]
        public string TCNO { get; set; }
        public string CarPlate { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Email { get; set; }

    }
}
