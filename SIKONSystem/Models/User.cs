using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{/// <summary>
/// SikonUser class
/// </summary>
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Navn")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Navn")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Email skal være gyldig.")]
        //[MinLength(6, ErrorMessage = "Email kan ikke være mindre end 6 karakterer.")]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Telefon Nr")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Post Nr")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        public bool AddAutismInfo { get; set; }

        //Navigation Properties
        public ICollection<Booking> Booking { get; set; }
        public Queue<WaitList> WaitList { get; set; }

        //Constructor
        public User()
        {

        }

        //Methods
        //public bool Partake(Lecture L)
        //{
        //    if (L.Bookings.Count < L.Room.Capacity)
        //    {
        //        return Attend(L);
        //    }
        //    else
        //    {
        //        new WaitList(this.UserId, L.LectureId);//Opdater
        //        return false;
        //    }

        //}

        //public bool Cancel(Lecture L)
        //{
        //    bool returnVal;
        //    if (L.Bookings.Contains(this.UserId))}
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

        //private bool Attend(Lecture L)
        //{
        //    L.Bookings.Add(new Booking(this.UserId, L.LectureId));
        //    //U.Agenda.Lectures.Add(L);
        //    return true;
        //}
    }
}
