using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Clinic
    {
        public int ClinicId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ClinicName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string ClinicAddress { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }

    }
}
