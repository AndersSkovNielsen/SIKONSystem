using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _timeFrame;

        public int TimeFrame
        {
            get { return _timeFrame; }
            set { _timeFrame = value; }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        //enum _categoryColour
        //{

        //}
        private int spaces;

        public int Spaces
        {
            get { return spaces; }
            set { spaces = Room.Capacity-_partakers.Count; }
        }


        private Room _room;

        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        private Collection<User> _partakers;

        public Collection<User> Partakers
        {
            get { return _partakers; }
            set { _partakers = value; }
        }


        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        private string _speaker;

        public string Speaker
        {
            get { return _speaker; }
            set { _speaker = value; }
        }

        private Queue<User> _waitingList;

        public Queue<User> WaitingList
        {
            get { return _waitingList; }
            set { _waitingList = value; }
        }

        public Lecture(string name, int timeFrame, Room room, Collection<User> partakers, string speaker, Queue<User> waitingList)
        {
            _name = name;
            _timeFrame = timeFrame;
            _room = room;
            _partakers = partakers;
            _speaker = speaker;
            _waitingList = waitingList;
        }

        public Lecture()
        {
            
        }
    }
}
