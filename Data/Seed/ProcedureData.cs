using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class ProcedureData
    {
        public static List<Procedure> SeedData()
        {
            List<Procedure> items = new List<Procedure>() {
                new Procedure { Name = "Root Canal", Description="Root canal treatment is the removal of the tooth’s pulp – a small, thread-like tissue in the center of the tooth."},
                new Procedure { Name = "Repairs", Description="Repair teeth, which have been compromised due to tooth decay (cavities) or trauma"},
                new Procedure { Name = "Dental Crowns (Caps)", Description="Crowns are dental restorations that protect damaged, cracked or broken teeth."},
                new Procedure { Name = "Bridges and Implants", Description="Bridges and implants are two ways of replacing a missing tooth or teeth."},
                new Procedure { Name = "Extractions", Description="A tooth extraction is the removal of a tooth from its socket in the bone."},
                new Procedure { Name = "Teeth Whitening", Description="Teeth naturally darken with age, however staining may be caused by various foods and beverages such as coffee, black tea, berries, smoking cigarettes, trauma to a tooth and some drugs such as tetracycline."},
           };

            return items;
        }

    }
}
