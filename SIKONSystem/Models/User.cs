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
        public int Id { get; set; }

        [Display(Name = "Telefon Nr")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Post Nr")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        [Display(Name = "Navn")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email skal være gyldig.")]
        [MinLength(6, ErrorMessage="Email kan ikke være mindre end 6 karakterer.")]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        //[Required]
        ////[CommonPasswords(ErrorMessage = "This password is too common")]
        //[DataType(DataType.Password)]
        //[ MinLength(8, ErrorMessage = "Password skal være over 8 karakterer.")]
        //public string Password { get; set; }

        //private Schedule _agenda;

        //public Schedule Agenda
        //{
        //    get { return _agenda; }
        //    set { _agenda = value; }
        //}

        //public User()
        //{
        //    _agenda = new Schedule();
        //}

        public User()
        {

        }
    }
}
