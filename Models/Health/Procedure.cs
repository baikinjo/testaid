using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Procedure
    {
        public int ProcedureId { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string  Name { get; set; }

        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }

        public List<SubProcedure> SubProcedures { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<PatientProcedure> PatientProcedures { get; set; }
    }
}
