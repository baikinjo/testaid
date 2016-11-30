using SecondAid.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed.Users
{
    public class UserWithRoles
    {
        private ApplicationUser _user;
        public ApplicationUser User { get { return _user; } }
        
        public string[] Roles { get; set; }

        public UserWithRoles(ApplicationDbContext _context, string name, string[] roles = null, 
            string password = "Open123$", int clinicId = 1)
        {
            
            if (roles != null)
                Roles = roles;
            else
                Roles = new string[] { };

            string email = name + "@gmail.com";

            _user = new ApplicationUser
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),

                UserName = email,
                NormalizedUserName = email.ToUpper(),

                PhoneNumber = "+1312341234",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ClinicId = clinicId,
                Clinic = _context.Clinics.FirstOrDefault(e => e.ClinicId == clinicId),
            };
            _user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(_user, password);
        }
    }
}
