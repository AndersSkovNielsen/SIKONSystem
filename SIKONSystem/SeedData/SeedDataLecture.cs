using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
                        CategoryId = 3,
                        Description = "Min historie om autisme",
                        TimeFrame = 2,
                        RoomId = 1,
                        Spaces = context.Room.Find(1).Capacity
                    },

                    new Lecture
                    {
                        Title = "Ro i sind",
                        StartTime = DateTime.Parse("10:30"),
                        Speaker = "Ove Larsen",
                        CategoryId = 6,
                        Description = "Metoder til at undgå stress",
                        TimeFrame = 3,
                        RoomId = 3,
                        Spaces = context.Room.Find(3).Capacity
                    },

                    new Lecture
                    {
                        Title = "Stille barn",
                        StartTime = DateTime.Parse("09:30"),
                        Speaker = "Nadia Uldum",
                        CategoryId = 4,
                        Description = "Pædagogik i børnehaven",
                        TimeFrame = 3,
                        RoomId = 4,
                        Spaces = context.Room.Find(4).Capacity
                    },

                    new Lecture
                    {
                        Title = "Autisme i samfundet",
                        StartTime = DateTime.Parse("11:00"),
                        Speaker = "Eva Marie Svendsen",
                        CategoryId = 2,
                        Description = "Viden i det danske samfund",
                        TimeFrame = 2,
                        RoomId = 2,
                        Spaces = context.Room.Find(2).Capacity
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
