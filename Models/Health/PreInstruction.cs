using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class PreInstruction
    {
        public int PreInstructionId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }

        [Display(Name = "Procedure")]
        public int SubProcedureId { get; set; }
        public SubProcedure SubProcedure { get; set; }
    }
}
