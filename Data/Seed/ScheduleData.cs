using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class ScheduleData
    {
        public static List<Schedule> SeedData(ApplicationDbContext context)
        {
            List<Schedule> items = new List<Schedule>() {
                new Schedule {
                    Patient = context.ApplicationUser.FirstOrDefault(s => s.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(s => s.Name == "Repairs"),
                    Time = Convert.ToDateTime("2016/12/04 8:30 am"),
                },

                new Schedule
                {
                    Patient = context.ApplicationUser.FirstOrDefault(s => s.UserName == "patient@gmail.com"),
                    Procedure = context.Procedures.FirstOrDefault(s => s.Name == "Teeth Whitening"),
                    Time = Convert.ToDateTime("2016/12/10 1:30 pm"),
                }
           };

            return items;
        }

    }
}