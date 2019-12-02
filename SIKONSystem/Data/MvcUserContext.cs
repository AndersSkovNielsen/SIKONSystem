using Microsoft.EntityFrameworkCore;
using SIKONSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Data
{
    public class MvcUserContext : DbContext
        {
            public MvcUserContext(DbContextOptions<MvcUserContext> options)
                : base(options)
            {
            }

            public DbSet<User> User { get; set; }
        }
    }
