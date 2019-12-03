﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
using SIKONSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcUserContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcUserContext>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Name = "James",
                        Email = "lol@me.dk",
                        Address = "Hopsavej 2",
                        Telephone = "10101010",
                        Zipcode = "1010"
                    },

                    new User
                    {
                        Name = "Billy",
                        Email = "rofl@me.dk",
                        Address = "Wassupgade 7",
                        Telephone = "93057193",
                        Zipcode = "4362"
                    },

                    new User
                    {
                        Name = "Mike",
                        Email = "wtf@me.dk",
                        Address = "Nejstræde 10",
                        Telephone = "49571383",
                        Zipcode = "8452"
                    },

                    new User
                    {
                        Name = "Hans",
                        Email = "wat@me.dk",
                        Address = "Kanon Alle 5",
                        Telephone = "10859291",
                        Zipcode = "1846"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}