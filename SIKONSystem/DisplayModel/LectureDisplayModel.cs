using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIKONSystem.Controllers;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.DisplayModel
{
    public class LectureDisplayModel
    {
         //private List<Room> makeRequest() {return   }
        public List<Lecture> LectureDisplayList { get; set; }
        public List<User> UserDisplayList { get; set; }
        public List<Room> RoomDisplayList { get; set; }
        public SelectList Rooms {
            get /*{ return  ;}*/; set; }

    }
}
