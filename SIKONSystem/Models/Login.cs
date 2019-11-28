using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Brugernavn skal være en gyldig @mail adresse")]
        public string Username { get; set; }
        [Required]
        //[CommonPasswords(ErrorMessage = "This password is too common")]
        [MinLength(8, ErrorMessage = "Dette kodeord er for kort.")]
        public string Password { get; set; }
    }
}
