using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class QuestionData
    {
        public static List<Question> SeedData(ApplicationDbContext context)
        {
            List<Question> items = new List<Question>() {
                new Question {
                    QuestionBody = "Is the pain constant?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Relaxing the pain")
                },
                new Question {
                    QuestionBody = "Do you feel tired?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Rest")
                },
                new Question {
                    QuestionBody = "Do you need to check which tooth is causing the gum priblem?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Examine")
                },
                new Question {
                    QuestionBody = "Did you need instruction on cleaning after the procedure?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Cleaning")
                },
                new Question {
                    QuestionBody = "Do you need to rinse your tooth after?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Do not rinse")
                },
                new Question {
                    QuestionBody = "What sort of food do you need to avoid?",
                    SubProcedure = context.SubProcedures.FirstOrDefault(q => q.Name == "Avoid dark staining drinks")
                },

           };

            return items;
        }
    }
}
