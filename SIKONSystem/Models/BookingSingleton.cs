using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class BookingSingleton
    {
        private static BookingSingleton _instance;
        
        public static BookingSingleton Instance()
        {
            if (_instance == null)
            {
              _instance= new BookingSingleton();
            }

            return _instance;

        }



        //public bool Partake(Lecture L, User U)
        //{
        //    if (L.Bookings.Count < L.Room.Capacity)
        //    {
        //        return Attend(U, L);
        //    }
        //    else
        //    {
        //        L.WaitList.Enqueue(U);
        //        return false;
        //    }

        //}

        //public bool Cancel(Lecture L, User U)
        //{
        //    bool returnVal;
        //    if (L.Bookings.Contains(U.UserId))
        //    {
        //        L.Bookings.Remove(U);

        //        if (L.WaitList.Peek() != null)
        //        {
        //            returnVal = Attend(L.WaitList.Dequeue(), L);
        //        }
        //        else returnVal = false;
        //    }
        //    else throw new Exception("Fejl i afmelding: Du var ikke tilmeldt denne begivenhed");
        //    return returnVal;
        //}

        //private bool Attend(User U, Lecture L)
        //{
        //    L.Bookings.Add(U.Booking);
        //    //U.Agenda.Lectures.Add(L);
        //    return true;
        //}

        private BookingSingleton()
        {
            
        }
    }
}
