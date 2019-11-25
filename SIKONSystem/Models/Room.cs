using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Room
    {
        private int _capacity;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public Room(int capacity)
        {
            _capacity = capacity;
        }
    }
}
