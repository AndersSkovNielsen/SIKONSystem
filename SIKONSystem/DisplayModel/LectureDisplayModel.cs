using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SIKONSystem.Controllers;
using SIKONSystem.Data;
using SIKONSystem.Models;


namespace SIKONSystem.DisplayModel
{
    public class LectureDisplayModel
    {
         //private List<Room> makeRequest() {return   }
         public List<Lecture> LextureDisplayList { get; set; }
        public Lecture LectureDisplay { get; set; }
        public List<User> UserDisplayList { get; set; }
        public List<Room> RoomDisplayList { get; set; }
        public SelectList Rooms { get /*{ return  ;}*/; set; }
        public string RoomName { get; set; }

        public string GatherSchedule(int noOfRooms, int noOfTimeBlocks, List<Lecture> lectures)
        {
            RoomDisplayList=new List<Room>();
            Room r1 = new Room(20, "A4 Køge");
            Room r2 = new Room(20, "B5 KBH");

            RoomDisplayList.Add(r1);
            RoomDisplayList.Add(r2);

            RoomDisplayList.Sort((x, y) => string.Compare(x.Name, y.Name));

            string headerstring ="";
            for (int i = 0; i < noOfRooms; i++)
            {
                headerstring = $"{headerstring}" + $"<th>| {RoomDisplayList[i].Name} |</th>";
            }
            
            List<string> retlist= new List<string>();
            string retValue = "";
            retValue=retValue+$"<thead><tr>{headerstring}</tr></thead>";

           

            //for (int i=0; i < noOfRooms; i++)
            //{

            //}
            ////await ;

            return retValue;
        }

        public string PrintSchedule(string task)
        {
            return task;
        }



    }
}
