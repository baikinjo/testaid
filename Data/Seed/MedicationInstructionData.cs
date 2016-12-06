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
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Oracort"),
                    Instruction = "Apply this medication 2 or 3 times daily, preferably after meals."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Lidex"),
                    Instruction = "Apply a small amount of medicine to the affected area."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Temovate"),
                    Instruction = "Gently rub the medicine in until it is evenly distributed, wash hands immediately."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Mortin"),
                    Instruction = "Do not use for more than 5 days for pain or 3 days for fever."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Chloraseptic"),
                    Instruction = "Allow to remain in place for at least 15 seconds and then spit out."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Orajel"),
                    Instruction = "Wait about 30 seconds to allow the pain reliever to numb the area."
                },
                new MedicationInstruction {
                    Medication = context.Medications.FirstOrDefault(p => p.Name == "Xylocaine"),
                    Instruction = "Do not take by mouth. Lidocaine topical is for use only on the skin."
                }
           };

            return items;
        }
    }
}
