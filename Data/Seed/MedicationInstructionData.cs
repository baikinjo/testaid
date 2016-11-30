using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class MedicationInstructionData
    {
        public static List<MedicationInstruction> SeedData(ApplicationDbContext context)
        {
            List<MedicationInstruction> items = new List<MedicationInstruction>() {
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Kenalog"),
                    Instruction = "Take a glass of milk every night before sleeping."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Ambesol"),
                    Instruction = "You must take vitamin D together with this medication."
                },
           };

            return items;
        }
    }
}
