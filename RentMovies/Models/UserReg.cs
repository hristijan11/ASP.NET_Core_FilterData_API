using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentMovies.UserRegistration
{
    public partial class UserReg
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Display(Name = "Password")]
        [Compare("ConfirmPassword")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Passowrd")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string UserEmail { get; set; }



        [Required(ErrorMessage = "Select the Martial Status")]
        [Display(Name = "Martial Status")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public bool MartialStatus { get; set; }
    }
}
