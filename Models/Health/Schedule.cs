using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Schedule
    {

        public int ScheduleId { get; set; }

        public DateTime Time { get; set; }

        public string PatientName { get; set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public bool IsCompleted { get; set; }

    }
}
