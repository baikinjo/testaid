using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class PreInstructionData
    {
        public static List<PreInstruction> SeedData(ApplicationDbContext context)
        {
            List<PreInstruction> items = new List<PreInstruction>() {
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Relaxing the pain"),
                    Title = "How to relax.",
                    Description = "This instruction is about how to relax your mind and soul.",
                },
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Rest"),
                    Title = "How to repair.",
                    Description = "This instruction is about tips on how to repair.",
                },
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Cleaning"),
                    Title = "How to cleaning.",
                    Description = "This instruction is about how to cleaning your mouth before procedure.",
                },
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Do not rinse"),
                    Title = "How to rinse.",
                    Description = "This instruction is about how to rinse your tooth.",
                },
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Examine"),
                    Title = "How to examine.",
                    Description = "This instruction is about how to examine your mind and soul.",
                },
                new PreInstruction {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Avoid dark staining drinks"),
                    Title = "What to avoid.",
                    Description = "Avoid Dark food like cofee, tea.",
                }
           };

            return items;
        }

    }
}
