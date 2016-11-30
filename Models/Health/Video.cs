using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Models.Health
{
    public class Video
    {
        public int VideoId { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "{0} cannot be longer than {1} characters.")]
        public string URL { get; set; }

        [Display(Name = "Sub-Procedure")]
        public int SubProcedureId { get; set; }
        public SubProcedure SubProcedure { get; set; }
    }
}
