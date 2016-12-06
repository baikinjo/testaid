using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class PatientProcedureData
    {
        public static List<PatientProcedure> SeedData(ApplicationDbContext context)
        {
            List<PatientProcedure> items = new List<PatientProcedure>()
            {
                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Root Canal"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Temovate"),
                },

                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Teeth Whitening"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Xylocaine"),
                },
                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Dental Crowns (Caps)"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Oracort"),
                },
                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Bridges and Implants"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Orajel"),
                },
                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Extractions"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Chloraseptic"),
                },
                new PatientProcedure
                {
                    Patient = context.ApplicationUser.FirstOrDefault(p => p.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Repairs"),
                    MedicationPrescribed = context.Medications.FirstOrDefault(p => p.Name == "Lidex"),
                },

            };


            return items;
        }
    }
}