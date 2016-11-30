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
           };

            return items;
        }

    }
}
