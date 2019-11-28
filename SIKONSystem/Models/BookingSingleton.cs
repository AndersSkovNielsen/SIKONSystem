using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class BookingSingleton
    {
        private static int _singleton;
        
        public int create()
        {
            if (_singleton == 0)
            {
              BookingSingleton Booker= new BookingSingleton();
            }

            return _singleton;

        }

        public bool Partake(Lecture L, User U)
        {
            if (L.Partakers.Count < L.Room.Capacity)
            {
                return Attend(U, L);
            }
            else
            {
                L.WaitingList.Enqueue(U);
                return false;
            }

        }

        public bool Cancel(Lecture L, User U)
        {
            bool returnVal;
            if (L.Partakers.Contains(U))
            {
                L.Partakers.Remove(U);

                if (L.WaitingList.Peek() != null)
                {
                    returnVal = Attend(L.WaitingList.Dequeue(), L);
                }
                else returnVal = false;
            }
            else throw  new Exception("Fejl i afmelding: Du var ikke tilmeldt denne begivenhed");
            return returnVal;
        }

        private bool Attend(User U, Lecture L)
        {
            L.Partakers.Add(U);
            U.Agenda.Lectures.Add(L);
            return true;
        }

        private BookingSingleton()
        {
            _singleton++;
        }
    }
}
