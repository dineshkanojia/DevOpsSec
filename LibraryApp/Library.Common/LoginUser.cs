using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Common
{
    public class LoginUser
    {

        public Guid UserId { get; set; }
        [Key]
        [DisplayName("User Name")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [DisplayName("Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Mobile is required.")]
        [DisplayName("Mobile")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [DisplayName("Email Id")]
        [Required(ErrorMessage = "Email Id is required.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string EmaiId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public bool? IsDelete { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
