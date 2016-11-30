using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class MedicationInstruction
    {
        public int MedicationInstructionId { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Instruction { get; set; }

        [Display(Name = "Medication")]
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
    }
}
