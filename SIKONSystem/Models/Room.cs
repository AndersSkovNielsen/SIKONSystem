﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Room
    {
        private int _capacity;

        [Display(Name="Kapacitet")]
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

        [Display(Name="Lokale")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        public Room(int capacity, string name)
        {
            _capacity = capacity;
            _name = name;
        }


        public Room() { }
    }
}
