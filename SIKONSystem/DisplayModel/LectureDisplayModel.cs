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

        public async Task<string> GatherSchedule(int noOfRooms, int noOfTimeBlocks, List<Lecture> lectures)
        {// Hvordan kan vi tilføje asyncronitet til denne metode?? -Frederik
            RoomDisplayList=new List<Room>();
            Room r1 = new Room(20, "A4 Køge");
            Room r2 = new Room(20, "B5 KBH");
            Room r3 = new Room(20, "C5 LGH");

            RoomDisplayList.Add(r1);
            RoomDisplayList.Add(r2);
            RoomDisplayList.Add(r3);

             RoomDisplayList.Sort((x, y) => string.Compare(x.Name, y.Name));

            string headerstring ="";
           for (int i = 0; i < noOfRooms; i++)
            {
                headerstring = $"{headerstring}" + $"<th>{RoomDisplayList[i].Name}</th>";
            }
            
            List<string> retlist= new List<string>();
            string retValue = "";
            retValue=retValue+$"<thead><tr/><th/>{headerstring}</tr></thead>";

           

            //for (int i=0; i < noOfRooms; i++)
            //{

            //}
            ////await ;

            return retValue;
        }

        public string PrintSchedule(Task<string> task)
        {
            return task.Result;
        }



    }
}
