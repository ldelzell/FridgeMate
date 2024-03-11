using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Your Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Your Name must contain only letters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Your Name must contain only letters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Your Phonenumber is Required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Phonenumber must be a positive number.")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Your Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9@.]+$", ErrorMessage = "Your Email must be valid!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required!")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [BindProperty, Required(ErrorMessage = "Image path is required.")]
        public IFormFile Image { get; set; }

        public RegisterViewModel() { }
    }
}
