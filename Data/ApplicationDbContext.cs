using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models;
using SecondAid.Models.Health;
using OpenIddict;

namespace SecondAid.Data
{
    public class ApplicationDbContext : OpenIddictDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<SubProcedure> SubProcedures { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationInstruction> MedicationInstructions { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<PreInstruction> PreInstructions { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
