using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class PatientProcedure
    {
        public int PatientProcedureId { get; set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; } 


        public string Id { get; set; } 
        public ApplicationUser Patient { get; set; }


        public int MedicationId { get; set; }
        public Medication MedicationPrescribed { get; set; }
    }
}
