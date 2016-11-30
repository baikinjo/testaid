using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class SubProcedure
    {
        public int SubProcedureId { get; set; }

        [Display(Name = "Sub-procedure")]
        [Required]
        [MaxLength(80, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }

        [Display(Name = "Procedure")]
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public List<Video> Videos { get; set; }
        public List<PreInstruction> PreInstructions { get; set; }
    }
}
