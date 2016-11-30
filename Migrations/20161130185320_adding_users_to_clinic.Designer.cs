using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SecondAid.Data;

namespace SecondAid.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161130185320_adding_users_to_clinic")]
    partial class adding_users_to_clinic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictApplication", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ClientId");

                    b.Property<string>("ClientSecret");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LogoutRedirectUri");

                    b.Property<string>("RedirectUri");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("OpenIddictApplications");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictAuthorization", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Scope");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictAuthorizations");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictScope", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OpenIddictScopes");
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ApplicationId");

                    b.Property<string>("AuthorizationId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("AuthorizationId");

                    b.ToTable("OpenIddictTokens");
                });

            modelBuilder.Entity("SecondAid.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressCountry");

                    b.Property<string>("AddressPostalCode");

                    b.Property<string>("AddressProvince");

                    b.Property<string>("AddressStreet");

                    b.Property<int>("ClinicId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NextOfKinFullName");

                    b.Property<string>("NextOfKinPhoneNumber");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PersonalHealthNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClinicAddress")
                        .IsRequired();

                    b.Property<string>("ClinicName")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("MedicationId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("SecondAid.Models.Health.MedicationInstruction", b =>
                {
                    b.Property<int>("MedicationInstructionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("MedicationId");

                    b.HasKey("MedicationInstructionId");

                    b.HasIndex("MedicationId");

                    b.ToTable("MedicationInstructions");
                });

            modelBuilder.Entity("SecondAid.Models.Health.PreInstruction", b =>
                {
                    b.Property<int>("PreInstructionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("SubProcedureId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("PreInstructionId");

                    b.HasIndex("SubProcedureId");

                    b.ToTable("PreInstructions");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Procedure", b =>
                {
                    b.Property<int>("ProcedureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("ProcedureId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ExpectedAnswer");

                    b.Property<bool>("PatientAnswer");

                    b.Property<string>("QuestionBody");

                    b.Property<int?>("QuestionnaireId");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Questionnaire", b =>
                {
                    b.Property<int>("QuestionnaireId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<int>("SubProcedureId");

                    b.HasKey("QuestionnaireId");

                    b.HasIndex("SubProcedureId");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("SecondAid.Models.Health.SubProcedure", b =>
                {
                    b.Property<int>("SubProcedureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<int>("ProcedureId");

                    b.Property<int?>("QuestionId");

                    b.HasKey("SubProcedureId");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SubProcedures");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("SubProcedureId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("VideoId");

                    b.HasIndex("SubProcedureId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SecondAid.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SecondAid.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecondAid.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenIddict.OpenIddictToken", b =>
                {
                    b.HasOne("OpenIddict.OpenIddictApplication")
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("OpenIddict.OpenIddictAuthorization")
                        .WithMany("Tokens")
                        .HasForeignKey("AuthorizationId");
                });

            modelBuilder.Entity("SecondAid.Models.ApplicationUser", b =>
                {
                    b.HasOne("SecondAid.Models.Health.Clinic", "Clinic")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecondAid.Models.Health.MedicationInstruction", b =>
                {
                    b.HasOne("SecondAid.Models.Health.Medication", "Medication")
                        .WithMany("MedicationInstructions")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecondAid.Models.Health.PreInstruction", b =>
                {
                    b.HasOne("SecondAid.Models.Health.SubProcedure", "SubProcedure")
                        .WithMany("PreInstructions")
                        .HasForeignKey("SubProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecondAid.Models.Health.Question", b =>
                {
                    b.HasOne("SecondAid.Models.Health.Questionnaire")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Questionnaire", b =>
                {
                    b.HasOne("SecondAid.Models.Health.SubProcedure", "SubProcedure")
                        .WithMany()
                        .HasForeignKey("SubProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecondAid.Models.Health.SubProcedure", b =>
                {
                    b.HasOne("SecondAid.Models.Health.Procedure", "Procedure")
                        .WithMany("SubProcedures")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecondAid.Models.Health.Question")
                        .WithMany("SubProcedures")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("SecondAid.Models.Health.Video", b =>
                {
                    b.HasOne("SecondAid.Models.Health.SubProcedure", "SubProcedure")
                        .WithMany("Videos")
                        .HasForeignKey("SubProcedureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
