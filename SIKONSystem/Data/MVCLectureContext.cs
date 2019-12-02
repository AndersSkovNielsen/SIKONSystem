using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Models;

namespace SIKONSystem.Data
{
    public class MVCLectureContext : DbContext
    {

        public MVCLectureContext(DbContextOptions<MVCLectureContext> options)
            : base(options)
        {
        }

        public DbSet<Lecture> Lecture { get; set; }
    }
    
    
}
