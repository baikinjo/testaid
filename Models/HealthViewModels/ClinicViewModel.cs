using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.HealthViewModels
{
    public class ClinicViewModel
    {
        public int ClinicId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ClinicName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string ClinicAddress { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
