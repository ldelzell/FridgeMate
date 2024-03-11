using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BLL.Models;

namespace Web.ViewModels
{
    public class UserViewModel
    {
       //public byte[] Image { get; set; }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is Required!"),PasswordPropertyText]
        public string Password { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        


        public UserViewModel(string? firstName, string? lastName, int phoneNumber, string email, string username, string password/*, string imagePath*/)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = username;
            Password = password;
            //ImagePath = imagePath;
        }
        public UserViewModel(string? firstName, string? lastName, int phoneNumber, string email, string username, string password , string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = username;
            Password = password;
            ImagePath = imagePath;
        }
        public UserViewModel() { }

    }
}
