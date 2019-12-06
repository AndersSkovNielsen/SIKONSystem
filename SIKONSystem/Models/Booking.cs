using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }


        //Navigation Properties
        public User User { get; set; }
        public Lecture Lecture { get; set; }
    }
}
