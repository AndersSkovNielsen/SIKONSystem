using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    /// <summary>
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
        [EmailAddress(ErrorMessage = "Email skal være gyldig.")]
        [MinLength(6, ErrorMessage = "Email kan ikke være mindre end 6 karakterer.")]
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
        public Booking Partake(Lecture L)
        {
            if (L.Bookings.Count < L.Room.Capacity)
            {
                return Attend(L,this);
            }
            else
            {
                new WaitList(this.UserId, L.LectureId); //Opdater
                return null;
            }

        }

        public Booking Attend(Lecture L, User U)
        {
            return new Booking(U.UserId, L.LectureId);
        }

        public Booking Cancel(Lecture L)
        {
            Booking returnVal=null;
            foreach (Booking booking in L.Bookings)
            {
                if (booking.UserId==this.UserId)
                {
                    L.Bookings.Remove(booking);
                    if (L.WaitList.Count != 0)
                    {
                        returnVal = Attend(L, L.WaitList.Dequeue().User);

                    }
                    else returnVal = null;
                }
                else
                {
                    returnVal = null;
                    throw new Exception("Fejl i afmelding: Du var ikke tilmeldt denne begivenhed");
                }
            }

            return returnVal;
        }


    }
}
