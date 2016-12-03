using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Schedule
    {

        public int ScheduleId { get; set; }

        [Display(Name ="Procedure Date")]
        public DateTime Time { get; set; }

        [Display(Name = "Procedure Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Patient Username")]
        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }

        [Display(Name = "Procedure Name")]
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
    }
}
