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

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



    }
}
