using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIKONSystem.Models;

namespace SIKONSystem.SeedData
{
    public class SeedDataLecture
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDbContext>>()))
            {
                // Look for any movies.
                if (context.Lecture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lecture.AddRange(
                    new Lecture
                    {
                        Title = "Autisme og mig",
                        StartTime = DateTime.Parse("09:00"),
                        Speaker = "Karl Bøje",
                        Category = LectureCategory.Autisme,
                        Description = "Min historie om autisme",
                        TimeFrame = 2
                    },

                    new Lecture
                    {
                        Title = "Ro i sind",
                        StartTime = DateTime.Parse("10:30"),
                        Speaker = "Ove Larsen",
                        Category = LectureCategory.Forplejning,
                        Description = "Metoder til at undgå stress",
                        TimeFrame = 3
                    },

                    new Lecture
                    {
                        Title = "Stille barn",
                        StartTime = DateTime.Parse("09:30"),
                        Speaker = "Nadia Uldum",
                        Category = LectureCategory.PædagogiskUdvikling,
                        Description = "Pædagogik i børnehaven",
                        TimeFrame = 3
                    },

                    new Lecture
                    {
                        Title = "Autisme i samfundet",
                        StartTime = DateTime.Parse("11:00"),
                        Speaker = "Eva Marie Svendsen",
                        Category = LectureCategory.Temagrupper,
                        Description = "Viden i det danske samfund",
                        TimeFrame = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
