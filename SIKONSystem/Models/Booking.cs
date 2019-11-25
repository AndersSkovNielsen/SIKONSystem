using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Booking
    {
        public bool Partake(Lecture L, User U)
        {
            if (L.Partakers.Count < L.Room.Capacity)
            {
                L.Partakers.Add(U);
                return true;
            }
            else
            {
                L.WaitingList.Enqueue(U);
                return false;
            }

        }

        public bool Cancel(Lecture L, User U)
        {
            if (L.Partakers.Contains(U))
            {
                
                L.Partakers.Remove(U);

                if (L.WaitingList.Peek() != null)
                {
                    L.Partakers.Add(L.WaitingList.Dequeue());
                }

                return true;
            }
            else return false;
        }
    }
}
