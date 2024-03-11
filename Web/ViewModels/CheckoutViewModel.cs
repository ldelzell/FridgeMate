using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Your Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Your Name must contain only letters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your Name Is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Your Name must contain only letters.")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Your Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9@.]+$", ErrorMessage = "Your Email must be valid!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adress is Required!")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Country is Required!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Zip Code is Required!")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "The name of the card holder is Required!")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Your Name must contain only letters.")]
        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "Card Number is Required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Card Number must be a positive number.")]
        public int CardNumber { get; set;}
        [Required(ErrorMessage = "Expiration Date is Required!")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Please enter a valid expiration date in the format MM/YY.")]
        public string CardExperationDate { get; set; }
        [Required(ErrorMessage = "CVV is Required!")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV must be exactly 3 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CVV must contain only numeric digits.")]
        public string CVV { get; set; }


    }
}
