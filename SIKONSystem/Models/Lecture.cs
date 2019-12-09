using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public int RoomId { get; set; }

        private string _title;
        
        [Required]
        [Display(Name= "Titel")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private DateTime _startTime;
        [Display(Name = "Starttidspunkt")]
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _speaker;
        [Display(Name = "Oplægsholder:")]
        public string Speaker
        {
            get { return _speaker; }
            set { _speaker = value; }
        }

        public LectureCategory Category { get; set; }

        private string _description;
        [Display(Name = "Beskrivelse:")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _timeFrame;

        public int TimeFrame
        {
            get { return _timeFrame; }
            set { _timeFrame = value; }
        }

        private int _spaces;

        [Display(Name="Antal Pladser")]
        public int Spaces
        {
            get { return _spaces; }
            set { _spaces = Room.Capacity-(Bookings.Count-1); }
        }

        //Navigation Properties
        private Room _room;

        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        public ICollection<Booking> Bookings { get; set; }

        public Queue<WaitList> WaitList { get; set; }

        //Constructor
        public Lecture()
        {
            Bookings=new List<Booking>();
            
            
        }
    }
}
