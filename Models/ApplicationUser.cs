using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SecondAid.Models.Health;
using System.ComponentModel.DataAnnotations;

namespace SecondAid.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // http://www.itorian.com/2013/11/customize-users-profile-in-aspnet.html

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PersonalHealthNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NextOfKinFullName { get; set; }
        public string NextOfKinPhoneNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }

        [Display(Name = "Clinic")]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }


    }
}
