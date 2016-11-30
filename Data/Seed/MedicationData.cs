using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class MedicationData
    {
        public static List<Medication> SeedData()
        {
            List<Medication> items = new List<Medication>() {
                new Medication { Name = "Kenalog", Description="Anti-inflammatory drug"},
                new Medication { Name = "Oracort", Description="Anti-inflammatory drug"},
                new Medication { Name = "Lidex", Description="Anti-inflammatory drug"},
                new Medication { Name = "Temovate", Description="Anti-inflammatory drug"},
                new Medication { Name = "Motrin", Description="Anesthetic"},
                 new Medication { Name = "Ambesol", Description="Anesthetic"},
                 new Medication { Name = "Chloraseptic", Description="Anesthetic"},
                 new Medication { Name = "Orajel", Description="Anesthetic"},
                  new Medication { Name = "Xylocaine", Description="Anesthetic"},
          };

            return items;
        }

    }
}
