using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Questionnaire
    {
        public int QuestionnaireId { get; set; }

        [Required]
        [Display(Name = "Questionnaire Name")]
        [MaxLength(30, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Sub Procedure")]
        public int SubProcedureId { get; set; }
        public SubProcedure SubProcedure { get; set; }

        [ScaffoldColumn(false)]
        public List<Question> Questions { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

    }
}
