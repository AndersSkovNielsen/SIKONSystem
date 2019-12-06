using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Lecture LectureDisplay { get; set; } = new Lecture();
        public List<User> UserDisplayList { get; set; }
        public List<Room> RoomDisplayList { get; set; }
        public SelectList Rooms { get /*{ return  ;}*/; set; }
        public string RoomName { get; set; }

        public async Task<string> GatherSchedule(int noOfRooms, int noOfTimeBlocks, List<Lecture> lectures)
        {// Hvordan kan vi tilføje asyncronitet til denne metode?? -Frederik


            //placeholder operationer
            RoomDisplayList=new List<Room>();
            Room r1 = new Room(20, "A4 Køge");
            Room r2 = new Room(20, "B5 KBH");
            Room r3 = new Room(20, "C5 LGH");

            RoomDisplayList.Add(r1);
            RoomDisplayList.Add(r2);
            RoomDisplayList.Add(r3);
            //slut på placeholder ops

             RoomDisplayList.Sort((x, y) => string.Compare(x.Name, y.Name));
             string retValue = "";
            string headerstring ="";
            for (int iTime = 0; iTime < noOfTimeBlocks; iTime++)
            {
                if (iTime == 0)
                {
                    for (int iRoom = 0; iRoom < noOfRooms; iRoom++)
                    {
                        headerstring = $"{headerstring}" + $"<th>{RoomDisplayList[iRoom].Name}</th>";
                    }

                    List<string> retlist = new List<string>();
                    
                    retValue = $"<thead><tr/><th/>{headerstring}</tr></thead>";
                }

                else
                {
                    string lineString = "";
                                                //noOfRooms har +1 fordi jeg bruger index 0 tid horisontalt til tidsangivelse
                    for (int iRoom = 0; iRoom < noOfRooms+1; iRoom++)
                    {
                        if (iRoom == 0)
                        {
                            //skriv tidsblok interval på første kolonne af hver række
                            lineString = $"<th>Blok {iTime}</th>";
                        }
                        else
                        {        //errorprevetion room existerer ikke
                                 //iRoom -1 er igen fordi index 0 bruges til tidsangivelse
                            if(LextureDisplayList[iRoom - 1].Room == null)
                            {
                                //placholder til test
                                LextureDisplayList[iRoom - 1].Room = RoomDisplayList[iRoom-1];
                            }
                            else
                            {
                            
                                if (LextureDisplayList[iRoom - 1].Room.Name == RoomDisplayList[iRoom - 1].Name)
                                {
                                    //indsæt lecture i tabellen
                                    lineString = lineString + $"<td>{LextureDisplayList[iRoom - 1].Title}</td>";
                                }
                                else
                                {
                                    lineString = lineString + $"<td></td>";
                                }
                            }
                        }
                    }
                    retValue = retValue + $"<tr>{lineString}</tr>";
                }
            }
            return retValue;
        }

    

        public string PrintSchedule(Task<string> task)
        {
            return task.Result;
        }

    }
}
