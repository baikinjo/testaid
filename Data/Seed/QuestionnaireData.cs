using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class QuestionnaireData
    {
        public static List<Questionnaire> SeedData(ApplicationDbContext context)
        {
            List<Questionnaire> items = new List<Questionnaire>()
            {
                new Questionnaire
                {
                    Name = "Relax Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Relaxing the pain"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/01 8:30 am")
                },
                new Questionnaire
                {
                    Name = "Rest Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Rest"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/02 10:30 am")
                },
                new Questionnaire
                {
                    Name = "Examine Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Examine"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/11 12:30 pm")
                },
                new Questionnaire
                {
                    Name = "Cleaning Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Cleaning"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/16 3:00 pm")
                },
                new Questionnaire
                {
                    Name = "Rinse Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Do not rinse"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/16 3:30 pm")
                },
                new Questionnaire
                {
                    Name = "Food Questionnaire",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name =="Avoid dark staining drinks"),
                    CreatedBy = "admin@gmail.com",
                    DateCreated = Convert.ToDateTime("2016/12/18 6:30 pm")
                }
            };


            return items;
        }
    }
}
