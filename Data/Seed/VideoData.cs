using SecondAid.Models.Health;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAid.Data.Seed
{
    public class VideoData
    {
        public static List<Video> SeedData(ApplicationDbContext context)
        {
            List<Video> items = new List<Video>() {
                new Video {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Relaxing the pain"),
                    Title = "How to relax.",
                    Description = "This video shows some tips on how to relax your mind and soul.",
                    URL = "https://www.youtube.com/how-to-relax",
                },
                new Video {
                    SubProcedure = context.SubProcedures.FirstOrDefault(p => p.Name == "Rest"),
                    Title = "How to repair.",
                    Description = "This video shows some tips on how to repair.",
                    URL = "https://www.youtube.com/how-to-repair",
                },
           };

            return items;
        }

    }
}
