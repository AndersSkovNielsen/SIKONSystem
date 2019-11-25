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
        [EmailAddress(ErrorMessage = "Usernames must be valid email address")]
        public string Username { get; set; }
        [Required]
        //[CommonPasswords(ErrorMessage = "This password is too common")]
        [MinLength(8, ErrorMessage = "This password is too short")]
        public string Password { get; set; }
    }
}
