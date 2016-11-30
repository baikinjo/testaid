using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Question
    {
        public int QuestionId { get; set; }

        [Display(Name = "Question")]
        public string QuestionBody { get; set; }
        
        public int SubProcedureId { get; set; }
        public SubProcedure SubProcedure { get; set; }
    }
}
