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
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Dental Crowns (Caps)"),
                    Name = "Examine",
                    Description ="Patient gets temporary crowns for test, then permanent crowns after 2 weeks."
                },
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Bridges and Implants"),
                    Name = "Cleaning",
                    Description ="Patient should have special cleaning brush from the dentist."
                },
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Extractions"),
                    Name = "Do not rince",
                    Description ="Avoid all brushing, rinsing or spitting the day of the surgery."
                },
                new SubProcedure {
                    Procedure = context.Procedures.FirstOrDefault(p => p.Name == "Teeth Whitening"),
                    Name = "Avoid dark staining drinks",
                    Description ="Avoid all dark staining foods like bolognaise, soy sauce, red meat, chocolate and all fruit except bananas."
                }
           };

            return items;
        }

    }
}
