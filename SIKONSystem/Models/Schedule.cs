using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Schedule
    {
        private Collection<Lecture> _lectures;

        public Collection<Lecture> Lectures
        {
            get { return _lectures; }
            set { _lectures = value; }
        }

        private Collection<Room> _rooms;

        public Collection<Room> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        public Schedule()
        {
            _lectures =new Collection<Lecture>();
            _rooms = new Collection<Room>();
        }
    }
}
