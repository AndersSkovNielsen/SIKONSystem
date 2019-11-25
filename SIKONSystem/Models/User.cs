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
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email skal være gyldig.")]
        [MinLength(6, ErrorMessage="Email kan ikke være mindre end 6 karakterer.")]
        public string Email { get; set; }
        [Required]
        //[CommonPasswords(ErrorMessage = "This password is too common")]
        [DataType(DataType.Password)]
        [ MinLength(8, ErrorMessage = "Password skal være over 8 karakterer.")]
        public string Password { get; set; }
    }
}
