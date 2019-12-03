using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Models;

namespace SIKONSystem.Data
{
    public class MvcRoomContext:DbContext
    {
        public MvcRoomContext(DbContextOptions<MvcRoomContext> options)
            : base(options)
        {
        }
        public DbSet<SIKONSystem.Models.Room> Room { get; set; }
    }
}
