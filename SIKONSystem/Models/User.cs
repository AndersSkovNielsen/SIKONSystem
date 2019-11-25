using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class User
    {
        [Required]
        [EmailAddress(ErrorMessage = "Usernames must be valid email address")]
        [MinLength(6,ErrorMessage="address minimum 6 characters")]
        public string Username { get; set; }
        [Required]
        //[CommonPasswords(ErrorMessage = "This password is too common")]
        [DataType(DataType.Password)]
        [ MinLength(8, ErrorMessage = "This password is too short")]
        public string Password { get; set; }
    }
}
