using SecondAid.Models.Health;
using System;
using System.Linq;

namespace SecondAid.Data.Seed
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Procedures.Any()) {
                db.Procedures.AddRange(ProcedureData.SeedData());
                db.SaveChanges();
            }

            if (!db.Medications.Any())
            {
                db.Medications.AddRange(MedicationData.SeedData());
                db.SaveChanges();
            }

            if (!db.SubProcedures.Any())
            {
                db.SubProcedures.AddRange(SubProcedureData.SeedData(db));
                db.SaveChanges();

                foreach (var item in db.SubProcedures.ToList())
                {
                    Questionnaire newQuestionnaire = new Questionnaire();

                    newQuestionnaire.CreatedBy = "admin@gmail.com";
                    newQuestionnaire.DateCreated = DateTime.Today;
                    newQuestionnaire.Name = item.Name + " Questionnaire";
                    newQuestionnaire.SubProcedure = item;
                    newQuestionnaire.SubProcedureId = item.SubProcedureId;

                    // empty questions array that will be later updated once questions are added;
                    newQuestionnaire.Questions = new System.Collections.Generic.List<Question>();

                    Console.WriteLine("Adding Questionnare: " + newQuestionnaire.Name);

                    db.Questionnaires.Add(newQuestionnaire);
                }
                db.SaveChanges();
            }

            if (!db.MedicationInstructions.Any())
            {
                db.MedicationInstructions.AddRange(MedicationInstructionData.SeedData(db));
                db.SaveChanges();
            }

            if (!db.Videos.Any())
            {
                db.Videos.AddRange(VideoData.SeedData(db));
                db.SaveChanges();
            }

            if (!db.PreInstructions.Any())
            {
                db.PreInstructions.AddRange(PreInstructionData.SeedData(db));
                db.SaveChanges();
            }

            if (!db.Clinics.Any())
            {
                db.Clinics.AddRange(ClinicData.SeedData());
                db.SaveChanges();
            }
        }
    }
}
