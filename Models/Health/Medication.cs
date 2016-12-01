using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Medication
    {
        [Display(Name = "Medication")]
        public int MedicationId { get; set; }

        [Required]
        [Display(Name = "Medication")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }

        public List<MedicationInstruction> MedicationInstructions { get; set; }
        public List<PatientProcedure> PatientProcedures { get; set; }
    }
}
