using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
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
                if (context.User.Any())
                {
                    return; // DB has been seeded
                }

                //context.Lecture.AddRange(
                //    new Lecture
                //    {
                //        Title = "Autisme og Personlige forhold",
                //        Bookings= new List<Booking>(),
                //        Category= LectureCategory.Autisme,
                //        Description = "test",
                //        LectureId = 2,
                //        Room= context.Room
                //    },

                //    new Room
                //    {
                //        Name = "C1.07",
                //        Capacity = 5
                //    },

                //    new Room
                //    {
                //        Name = "B3.04",
                //        Capacity = 25
                //    },

                //    new Room
                //    {
                //        Name = "A1.05",
                //        Capacity = 10
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}
