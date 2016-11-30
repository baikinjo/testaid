using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class SubProcedureData
    {
        public static List<SubProcedure> SeedData(ApplicationDbContext context)
        {
            List<SubProcedure> items = new List<SubProcedure>() {
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Root Canal"),
                    Name = "Relaxing the pain",
                    Description ="Patient can relax the pain by taking aspirin."
                },
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Repairs"),
                    Name = "Rest",
                    Description ="Patient should have at least 6 hours of sleep every night for six days."
                },
           };

            return items;
        }

    }
}
