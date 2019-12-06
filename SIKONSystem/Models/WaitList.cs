using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class WaitList
    {
        public int WaitListId { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Lecture Lecture { get; set; }

        //Constructor
        public WaitList()
        {
            
        }

        public WaitList(int userId, int lectureId)
        {
            UserId = userId;
            LectureId = lectureId;
        }
    }
}
