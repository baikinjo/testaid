using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class ClinicData
    {
        public static List<Clinic> SeedData()
        {
            List<Clinic> items = new List<Clinic>() {
                new Clinic { ClinicName = "Health Clinic", ClinicAddress = "123 Street", FirstName = "Default", LastName = "User",
                    PhoneNumber = "123-456-7890", ApplicationUsers = new List<Models.ApplicationUser>() },
                new Clinic { ClinicName = "Health World", ClinicAddress = "124 Street", FirstName = "Default", LastName = "User",
                    PhoneNumber = "123-556-7890", ApplicationUsers = new List<Models.ApplicationUser>() },
                new Clinic { ClinicName = "NorthWind Clinic", ClinicAddress = "125 Street", FirstName = "Default", LastName = "User",
                    PhoneNumber = "123-555-7890", ApplicationUsers = new List<Models.ApplicationUser>() },
          };

            return items;
        }
    }
}
